using Domain.Entities.MovimientoAggregate;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovimientoRepository: GenericRepositoryAsync<Movimiento>, IMovimientoRepository
    {
        private readonly DbSet<Movimiento> _movimiento;

        public MovimientoRepository(FondosContext dbContext) : base(dbContext)
        {
            _movimiento = dbContext.Set<Movimiento>();
        }

        public async Task<long> GetNuevoNumeroOp(long SucursalIdMov, DateTime FechaGrab)
        {
            long res = 1;

            var reg = await _dbContext.Movimiento
                .Where(x => x.SucursalIdMov == SucursalIdMov && x.FechaGrab.Date == FechaGrab)
                .OrderByDescending(x => x.NumeroOp)
                .FirstOrDefaultAsync();

            if (reg == null)
                res = 1;
            else
                res = reg.NumeroOp + 1;

            return res;
        }

        public async Task<List<Movimiento>> GetMovimientos(long CuentaId)
        {            
            var regs = await _dbContext.Movimiento
                .Include(x => x.Operacion)
                .Where(x => x.CuentaId == CuentaId )
                .OrderBy(x=>x.FechaOp).ThenBy(x => x.FechaGrab)
                .ToListAsync();
                        
            return regs;
        }
        public async Task<List<Movimiento>> GetMovimientos(long CuentaId, DateTime FechaDesde)
        {
            var regs = await _dbContext.Movimiento
                .Include(x => x.Operacion)
                .Where(x => x.CuentaId == CuentaId && x.FechaOp.Date >= FechaDesde)
                .OrderBy(x => x.FechaOp).ThenBy(x => x.FechaGrab)
                .ToListAsync();

            return regs;
        }

        public async override Task<Movimiento> AddAsync(Movimiento entity)
        {
            using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                await _dbContext.Movimiento.AddAsync(entity);
                _dbContext.CuentaSaldo.Attach(entity.CuentaSaldo);

                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }

            return (entity);
        }

        public async Task<CuentaSaldo> CuentaSaldo (long CuentaId)
        {
            var reg = await _dbContext.CuentaSaldo
                .Where(x => x.CuentaId == CuentaId)
                .FirstOrDefaultAsync();

            return reg;

        }
    }


}

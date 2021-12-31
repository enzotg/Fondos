using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.CuentaAggregate;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CuentaRepository : GenericRepositoryAsync<Cuenta>, ICuentaRepository
    {
        private readonly DbSet<Cuenta> _cuenta;

        public CuentaRepository(FondosContext dbContext) : base(dbContext)
        {
            _cuenta = dbContext.Set<Cuenta>();

        }

        public async Task<long> GetUltNumeroAsync(long CasaId)
        {
            if (CasaId == 0)
                return 0;

            var ult = await _dbContext.Cuenta.LastOrDefaultAsync(x => x.CasaId == CasaId);

            if (ult != null)
                return ult.Numero;
            else
                return 1;
        }
        public override async Task<Cuenta> GetByIdAsync(long id)
        {
            var res = await _dbContext.Cuenta
                .Where(x => x.Id == id)
                .Include(x=>x.CuentaPersona)                                
                .FirstOrDefaultAsync();

            return res;
        }

        public async Task<List<CuentaPersona>> GetIntegrantesByIdCuentaAsync(long CuentaId)
        {            
            var res = await _dbContext.CuentaPersona.Where(x => x.CuentaId == CuentaId).ToListAsync();
            return res;
        }

        public async Task<Cuenta> AddCuentaYPersAsync(Cuenta cuenta, List<CuentaPersona> cuentaPersona)
        {
            //transaction ...
            using (var transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
            {
                
                _dbContext.Cuenta.Add(cuenta);
                await _dbContext.SaveChangesAsync();

                cuentaPersona.ForEach(x => x.CuentaId = cuenta.Id);
                _dbContext.CuentaPersona.AddRange(cuentaPersona);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }

            return cuenta;
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


        /*public override async Task UpdateAsync(Cuenta entity){
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();}*/





    }
}

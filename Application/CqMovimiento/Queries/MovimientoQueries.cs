using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CqMovimiento.Queries
{
    public class MovimientoQueries : IMovimientoQueries
    {
        private IMovimientoRepository _movimientoRepository;

        public MovimientoQueries(IMovimientoRepository movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public async Task<MovimientoVM> GetById(long Id)
        {
            var res = (await _movimientoRepository.GetByIdAsync(Id));
            MovimientoVM mov = new MovimientoVM
            {
                Anulado = res.Anulado,
                CuentaId = res.CuentaId,
                FechaGrab = res.FechaGrab,
                FechaOp = res.FechaOp,
                Id=res.Id,
                Importe=res.Importe,
                InfAdicional=res.InfAdicional,
                NumeroOp=res.NumeroOp,
                OperacionId=res.OperacionId,
                SaldoGr=res.SaldoGr,
                SaldoOp=res.SaldoOp,
                SucursalIdMov= res.SucursalIdMov,
                UsuarioId=res.UsuarioId
            };
            return mov;
                
        }
        public async Task<List<MovimientosPorCuentaVM>> MovimientosPorCuenta(long CuentaId)
        {
            var res = (await _movimientoRepository.GetMovimientos(CuentaId))
                .Select(x => new MovimientosPorCuentaVM
                {
                    Fecha = x.FechaOp,
                    Opreacion = x.Operacion.Nombre,
                    Importe = x.Importe,
                    Saldo = x.SaldoOp
                })
                .ToList();

            return res;
        }
    }

    public class MovimientosPorCuentaVM
    {
        public DateTime Fecha { get; set; }

        public string Opreacion { get; set; }

        public double Importe { get; set; }

        public double Saldo { get; set; }
    }

    public class MovimientoVM
    {
        public long Id { get; set; }

        public long CuentaId { get; set; }

        public long SucursalIdMov { get; set; }

        public long NumeroOp { get; set; }

        public DateTime FechaOp { get; set; }

        public DateTime FechaGrab { get; set; }

        public long OperacionId { get; set; }

        public double Importe { get; set; }

        public double SaldoOp { get; set; }

        public double SaldoGr { get; set; }

        public long InfAdicional { get; set; }

        public long UsuarioId { get; set; }

        public bool Anulado { get; set; }

    }
}

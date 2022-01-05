using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Application.CqCuenta.Queries
{
    public class CuentaQueries : ICuentaQueries
    {
        private ICuentaRepository _cuentaRepository;

        public CuentaQueries(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task<CuentaVM> GetById(long Id)
        {
            var res = await _cuentaRepository.GetByIdAsync(Id);
            CuentaVM cuentaVM = new CuentaVM
            {
                CasaId = res.CasaId,
                EstadoId = res.EstadoId,
                FechaAlta = res.FechaAlta,
                Id = res.Id,
                Numero = res.Numero,
                TipoCuentaId = res.TipoCuentaId
            };
            return cuentaVM;
        }
    }
    public class CuentaVM
    {
        public long Id { get; set; }

        public long CasaId { get;  set; }

        public long Numero { get; set; }

        public long TipoCuentaId { get; set; }

        public DateTime FechaAlta { get; set; }

        public byte EstadoId { get; set; }

    }
}

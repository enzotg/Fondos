using Domain.Entities.MovimientoAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IMovimientoRepository : IGenericRepositoryAsync<Movimiento>
    {
        //Task<Movimiento> AddCuentaYPersAsync(Cuenta cuenta, List<CuentaPersona> cuentaPersona);
        Task<long> GetNuevoNumeroOp(long sucursalIdMov, DateTime FechaGrab);
        Task<CuentaSaldo> CuentaSaldo(long CuentaId);
        Task<List<Movimiento>> GetMovimientos(long cuentaId);
        Task<List<Movimiento>> GetMovimientos(long cuentaId, DateTime fechaOp);
    }
 
}

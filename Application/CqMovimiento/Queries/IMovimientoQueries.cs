using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.CqMovimiento.Queries
{
    public interface IMovimientoQueries
    {
        Task<MovimientoVM> GetById(long Id);
        Task<List<MovimientosPorCuentaVM>> MovimientosPorCuenta(long CuentaId);
    }
}
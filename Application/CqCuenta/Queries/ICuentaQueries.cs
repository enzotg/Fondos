using System.Threading.Tasks;

namespace Application.CqCuenta.Queries
{
    public interface ICuentaQueries
    {
        Task<CuentaVM> GetById(long Id);
    }
}
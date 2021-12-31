using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.CuentaAggregate;

namespace Infrastructure.Interfaces
{
    public interface ICuentaRepository : IGenericRepositoryAsync<Cuenta>
    {
        Task<Cuenta> AddCuentaYPersAsync(Cuenta cuenta, List<CuentaPersona> cuentaPersona);
        Task<List<CuentaPersona>> GetIntegrantesByIdCuentaAsync(long CuentaId);
        Task<long> GetUltNumeroAsync(long CasaId);

    }
}
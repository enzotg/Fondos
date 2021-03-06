using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.CuentaAggregate;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.CqCuenta.Commands
{
    public class CrearCuentaCommandHandler: IRequestHandler<CrearCuentaCommandRequest, long>
    {
        private ICuentaRepository _repo;

        public CrearCuentaCommandHandler(ICuentaRepository Repo)
        {
            _repo = Repo;
        }

        public async Task<long> Handle(CrearCuentaCommandRequest request, CancellationToken cancellationToken)
        {            
           var nuevo = new Cuenta(request.CasaId, await _repo.GetUltNumeroAsync(request.CasaId) , request.TipoCuentaId, request.Integrantes);
           var cp = new List<CuentaPersona>();
            foreach (var pers in request.Integrantes)
            {
                cp.Add(new CuentaPersona
                {
                    PersonaId = pers
                });
            }

            await _repo.AddCuentaYPersAsync(nuevo, cp);

            return nuevo.Id;
        }


    }
}

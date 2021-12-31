using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;

using MediatR;
namespace Application.CqPersona.Commands
{
    public class CreatePersonaCommandHandler:IRequestHandler<CreatePersonaCommandRequest,long>
    {
        private IGenericRepositoryAsync<Persona> _repo;

        public CreatePersonaCommandHandler(IGenericRepositoryAsync<Persona> Repo)
        {            
            _repo = Repo;
        }

        public async Task<long> Handle(CreatePersonaCommandRequest request, CancellationToken cancellationToken)
        {
            var p = new Persona(request.Documento, request.Cuil, request.ApNombre, request.TipoDocumentoId);

            await _repo.AddAsync(p);

            return p.Id;
        }

    }
}

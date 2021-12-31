using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CqPersona.Commands
{
    public class UpdatePersonaCommandHandler:IRequestHandler<UpdatePersonaCommandRequest, UpdatePersonaCommandResponse>
    {
        private IGenericRepositoryAsync<Persona> _repo;

        public UpdatePersonaCommandHandler(IGenericRepositoryAsync<Persona> Repo)
        {
            _repo = Repo;
        }

        public async Task<UpdatePersonaCommandResponse> Handle(UpdatePersonaCommandRequest request, CancellationToken cancellationToken)
        {
            var reg = await _repo.GetByIdAsync(request.Id);
            if(reg == null)
                throw new Exception("No existe registro con id " + request.Id.ToString());

            var modif = reg.Modificar(request.Documento, request.Cuil, request.ApNombre, request.TipoDocumentoId);

            await _repo.UpdateAsync(modif);

            var res = new UpdatePersonaCommandResponse
            {
                ApNombre = modif.ApNombre,
                Cuil = modif.Cuil,
                Documento = modif.Documento,
                TipoDocumentoId = modif.TipoDocumentoId,
                Id = modif.Id
            };

            return res;
        }

    }
}
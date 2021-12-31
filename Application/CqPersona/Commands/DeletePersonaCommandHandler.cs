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
    public class DeletePersonaCommandHandler:IRequestHandler<DeletePersonaCommandRequest,DeletePersonaCommandResponse>
    {
        private IGenericRepositoryAsync<Persona> _repo;

        public DeletePersonaCommandHandler(IGenericRepositoryAsync<Persona> Repo)
        {            
            _repo = Repo;
        }

        public async Task<DeletePersonaCommandResponse> Handle(DeletePersonaCommandRequest request, CancellationToken cancellationToken)
        {
            var reg = await _repo.GetByIdAsync(request.Id);
            if (reg == null)
                throw new Exception("No existe registro con id " + request.Id.ToString());

            //var modif = reg.de

            await _repo.DeleteAsync(reg);

            var result = new DeletePersonaCommandResponse();
            result.Id = reg.Id;

            return result;
        }

        public void Validate(DeletePersonaCommandRequest request)
        {
            if (request.Id == 0)
                throw new Exception("Cuenta ident. no puede ser cero. " );



        }
    }
}

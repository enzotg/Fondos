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
    public class BorrarPersonaCommandHandler:IRequestHandler<BorrarPersonaCommandRequest,long>
    {
        private IGenericRepositoryAsync<Persona> _repo;

        public BorrarPersonaCommandHandler(IGenericRepositoryAsync<Persona> Repo)
        {            
            _repo = Repo;
        }

        public async Task<long> Handle(BorrarPersonaCommandRequest request, CancellationToken cancellationToken)
        {
            var reg = await _repo.GetByIdAsync(request.Id);
            if (reg == null)
                throw new Exception("No existe registro con id " + request.Id.ToString());
            
            await _repo.DeleteAsync(reg);
            
            return reg.Id;
        }

        public void Validate(BorrarPersonaCommandRequest request)
        {
            if (request.Id == 0)
                throw new Exception("Cuenta ident. no puede ser cero. " );



        }
    }
}

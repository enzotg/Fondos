using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.CuentaAggregate;
using Infrastructure.Interfaces;
using MediatR;
using System.Linq;

namespace Application.CqCuenta.Commands
{
    public class ModificarCuentaCommandHandler : IRequestHandler<ModificarCuentaCommandRequest, ModificarCuentaCommandResponse>
    {
        private ICuentaRepository _repo;

        public ModificarCuentaCommandHandler(ICuentaRepository cuentaRepository)
        {
            _repo = cuentaRepository;

        }
        public async Task<ModificarCuentaCommandResponse> Handle(ModificarCuentaCommandRequest request, CancellationToken cancellationToken)
        {
            ModificarCuentaCommandResponse res = new ModificarCuentaCommandResponse();
            Validate(request);

            var reg = await _repo.GetByIdAsync(request.CuentaId);
            if (reg == null)
                throw new Exception("No existe registro con id " + request.CuentaId.ToString());

            var modif = reg.Modificar(request.TipoCuentaId, request.Integrantes);

            await _repo.UpdateAsync(modif);

            res.CasaId = modif.CasaId ;
            res.CuentaId = modif.Id;
            res.Numero = modif.Numero;

            return res;
        }
        public void Validate(ModificarCuentaCommandRequest request)
        {
            if(request.CuentaId==0)
                throw new Exception("Cuenta ident. no puede ser cero. " + request.CuentaId.ToString());

            if (request.TipoCuentaId == 0)
                throw new Exception("Tipo cuenta no puede ser cero. " + request.TipoCuentaId.ToString());
        }

    }
}

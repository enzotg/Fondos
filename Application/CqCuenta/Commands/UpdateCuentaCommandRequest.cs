using Domain.Entities.CuentaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CqCuenta.Commands
{
    public class UpdateCuentaCommandRequest:IRequest<UpdateCuentaCommandResponse>
    {
        public long CuentaId { get; set; }

        public long TipoCuentaId { get; set; }

        public List<long> Integrantes { get; set; }

        public UpdateCuentaCommandRequest()
        {
            Integrantes = new List<long>();
        }
    }
}

using Domain.Entities.CuentaAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CqCuenta.Commands
{
    public class CreateCuentaCommandRequest:IRequest<long>
    {
        public long CasaId { get; set; }

        //public long Numero { get; set; }        

        public long TipoCuentaId { get; set; }

        public List<long> Integrantes { get; set; }

        public CreateCuentaCommandRequest()
        {
            this.Integrantes = new List<long>();
        }
    }
}

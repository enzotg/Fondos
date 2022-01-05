using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.CqMovimiento.Commands
{
    public class NuevoMovimientoCommandRequest:IRequest<long>
    {
        public long CuentaId { get; set; }

        public long SucursalIdMov { get; set; }

        public long NumeroOp { get; set; }

        public DateTime FechaOp { get; set; }        

        public long OperacionId { get; set; }

        public double Importe { get; set; }

        public long InfAdicional { get; set; }

        public long UsuarioId { get; set; }

    }
}

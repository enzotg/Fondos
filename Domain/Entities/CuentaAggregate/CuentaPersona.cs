using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.CuentaAggregate
{
    public class CuentaPersona
    {
        public long Id { get; set; }

        public long CuentaId { get; set; }

        public long PersonaId { get; set; }

        public byte Orden { get; set; }

        public Cuenta Cuenta { get; set; }

        public Persona Persona { get; set; }
    }
}

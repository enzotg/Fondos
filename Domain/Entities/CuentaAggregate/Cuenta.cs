using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Entities.CuentaAggregate
{
    public class Cuenta
    {
        public long Id { get; private set; }

        public long CasaId { get; private set; }

        public long Numero { get; private set; }

        public long TipoCuentaId { get; private set; }

        public DateTime FechaAlta { get; private set; }

        public byte EstadoId { get; set; }

        public TipoCuenta TipoCuenta { get; private set; }

        public List<CuentaPersona> CuentaPersona { get; private set; }

        public Cuenta()
        {

        }

        public Cuenta(long casaId, long numero, long tipoCuentaId, List<long> Integrantes)
        {
            byte i = 1;
            //this.Id = cuentaId;
            this.CasaId = casaId;
            this.Numero = numero;
            this.FechaAlta = DateTime.Now;
            this.TipoCuentaId = tipoCuentaId;
            this.CuentaPersona = new List<CuentaPersona>();

            foreach(var  n in Integrantes)
            {
                CuentaPersona.Add(new CuentaPersona
                {
                     //CuentaId=cuentaId,
                     Orden=i++,
                     PersonaId = n
                });
            }
        }


        public Cuenta Modificar(long tipoCuentaId, List<long> Integrantes)
        {
            byte i = 1;

            this.TipoCuentaId = tipoCuentaId;
            this.CuentaPersona.RemoveAll(x => true);

            foreach(var p in Integrantes)
            {
                this.CuentaPersona.Add(new CuentaPersona
                {
                    CuentaId = this.Id,
                    Orden = i++,
                    PersonaId = p
                });
            }

            return this;
        }


    }
}

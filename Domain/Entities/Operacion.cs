using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Operacion
    {
        public long OperacionId { get; private set; }

        public string Nombre { get; private set; }

        public byte OperadorId  { get; private set; }

        public byte TipoOperacionId { get; private set; }

        public bool DisponibleOp { get; private set; }     

        public bool ProcesoMes { get; private set; }

        public bool Automatica { get; private set; }        

        public bool ImprimeCompr { get; private set; }

        public TipoOperacion TipoOperacion { get; private set; }

        public Operacion()
        {

        }

        public Operacion(long OperacionId, string Nombre, byte OperadorId, byte TipoOperacionId, bool DisponibleOp, bool ProcesoMes, bool Automatica, bool ImprimerCompr)
        {
            this.OperacionId = OperacionId;
            this.Nombre = Nombre;
            this.OperadorId = OperadorId;
            this.TipoOperacionId = TipoOperacionId;
            this.DisponibleOp = DisponibleOp;
            this.ProcesoMes = ProcesoMes;
            this.Automatica = Automatica;
            this.ImprimeCompr = ImprimeCompr;
        }
    }
}

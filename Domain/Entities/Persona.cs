using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Persona
    {
        public long Id { get; private set; }

        public long Documento { get; private set; }

        public long Cuil { get; private set; }
        
        public string ApNombre { get; private set; }

        public long TipoDocumentoId { get; private set; }

        public TipoDocumento TipoDocumento { get; private set; }

        public Persona()
        {

        }
        public Persona(long Documento, long Cuil, string ApNombre, long TipoDocumentoId)
        {
            if (Documento.ToString().Length < 3)
                throw new Exception("Error en documento");

            //Documento.ToString() == Cuil.ToString().Substring(2,8)            

            this.Documento = Documento;
            this.Cuil = Cuil;
            this.ApNombre = ApNombre;
            this.TipoDocumentoId = TipoDocumentoId;
        }

        public Persona Modificar(long Documento, long Cuil, string ApNombre, long TipoDocumentoId)
        {
            this.Documento = Documento;
            this.Cuil = Cuil;
            this.ApNombre = ApNombre;
            this.TipoDocumentoId = TipoDocumentoId;

            return this;
        }

    }
}

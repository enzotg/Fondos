using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using MediatR;

namespace Application.CqPersona.Commands
{
    public class CreatePersonaCommandRequest:IRequest<long>
    {
        public long Id { get; set; }

        public long Documento { get; set; }

        public long Cuil { get; set; }
        
        public string ApNombre { get; set; }

        public long TipoDocumentoId { get; set; }

 
    }
}

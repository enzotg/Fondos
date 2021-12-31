using MediatR;

namespace Application.CqPersona.Commands
{
    public class UpdatePersonaCommandRequest:IRequest<UpdatePersonaCommandResponse>
    {
        public long Id { get;  set; }

        public long Documento { get; set; }

        public long Cuil { get; set; }

        public string ApNombre { get; set; }

        public long TipoDocumentoId { get; set; }
        
    }
}
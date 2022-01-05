using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using MediatR;

namespace Application.CqPersona.Commands
{
    public class BorrarPersonaCommandRequest:IRequest<long>
    {
        public long Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IPersonaRepository : IGenericRepositoryAsync<Persona>
    {
    }
}

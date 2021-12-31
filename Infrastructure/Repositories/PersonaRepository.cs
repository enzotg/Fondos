using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories
{
    public class PersonaRepository : GenericRepositoryAsync<Persona>,IPersonaRepository
    {
        private readonly DbSet<Persona> _persona;

        public PersonaRepository(FondosContext dbContext) : base(dbContext)
        {
            _persona = dbContext.Set<Persona>();
        }

    }
}

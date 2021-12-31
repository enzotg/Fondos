using Domain.Entities;
using Domain.Entities.CuentaAggregate;
using Domain.Entities.MovimientoAggregate;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class FondosContext : DbContext
    {
        public FondosContext(DbContextOptions<FondosContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<TipoCuenta> TipoCuenta { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<CuentaPersona> CuentaPersona {get;set;}
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<CuentaSaldo> CuentaSaldo { get; set; }
        public DbSet<Operacion> Operacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>().HasData(
                new TipoDocumento { Id = 1, Nombre = "DNI" });

            /*var p1 = new Persona(1,123456789, 12345678900, "Persona 1", 1);
            var p2 = new Persona(2,123456799, 12345679900, "Persona 2", 1);

            modelBuilder.Entity<Persona>().HasData(p1);
            modelBuilder.Entity<Persona>().HasData(p2);
            */
            //modelBuilder.Entity<Cuenta>().HasData(
            //    new Cuenta(1, 1, 1, new List<long> { p1.Id, p2.Id}));

            modelBuilder.Entity<TipoOperacion>().HasData(
                new TipoOperacion { TipoOperacionId = 1, Nombre = "Comun" });

            modelBuilder.Entity<Operacion>().HasData(
                new Operacion(1,"Deposito", 1, 1, true, false, false, true));
            
            modelBuilder.Entity<Operacion>().HasData(
                new Operacion(2,"Extraccion", 2, 1, true, false, false, true));

        }

    }
}

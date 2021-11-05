using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TruckGest.BaseDatos.Maps;
using TruckGest.Models;

namespace TruckGest.BaseDatos
{
    public class TransportesContext : DbContext
    {
        public DbSet<Administrador> administradores { get; set; }
        public DbSet<Carro> carros { get; set; }
        public DbSet<Conductor> conductores { get; set; }
        public DbSet<Reporte> reportes { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AdministradorMap());
            modelBuilder.Configurations.Add(new CarroMap());
            modelBuilder.Configurations.Add(new ConductorMap());
            modelBuilder.Configurations.Add(new ReportesMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

        }
    }
}
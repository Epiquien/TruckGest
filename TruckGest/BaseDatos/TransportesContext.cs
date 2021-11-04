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
        public DbSet<Administrador> _Administradores { get; set; }
        public DbSet<Carro> _Carros { get; set; }
        public DbSet<Conductor> _Conductores { get; set; }
        public DbSet<Reportes> _Reportes { get; set; }
        public DbSet<Usuario> _Usuarios { get; set; }

     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new AdministradorMap());
           // modelBuilder.Configurations.Add(new CarroMap());
        }
    }
}
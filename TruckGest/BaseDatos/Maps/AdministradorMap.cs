using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class AdministradorMap : EntityTypeConfiguration<Administrador>
    {
        public AdministradorMap()
        {
            ToTable("Administrador");
            HasKey(o => o.id_admin);

            HasMany(o => o.conductores)
                .WithRequired(o => o.administrador)
                .HasForeignKey(o=>o.id_administrador);
        }
    }
}
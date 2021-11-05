using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class ConductorMap : EntityTypeConfiguration<Conductor>
    {
        public ConductorMap()
        {
            ToTable("Conductor");
            HasKey(o => o.id_conductor);

            HasMany(o => o.carros).WithRequired(o => o.conductor).HasForeignKey(o => o.id_conductor);
            //HasRequired(o => o.administrador).WithMany(o => o.conductores).HasForeignKey(o => o.id_administrador);
            HasMany(o => o.reportes).WithRequired(o => o.conductor).HasForeignKey(o => o.id_conductor);
            //HasRequired(o => o.usuario).WithRequiredPrincipal(o => o.conductor);
            //HasOptional(o => o.usuario).WithRequired(o => o.conductor);
        }
    }
}
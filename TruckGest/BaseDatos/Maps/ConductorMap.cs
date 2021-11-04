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
            HasKey(o => o.Id);
            HasRequired(o => o.carro);

            HasMany(o => o.reportes).WithRequired(o => o.conductor).HasForeignKey(o => o.Id);
        }
    }
}
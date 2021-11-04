using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class ReportesMap : EntityTypeConfiguration<Reportes>
    {
        public ReportesMap()
        {
            ToTable("Reportes");
            HasKey(o => o.Id);

            HasRequired(o => o.administrador).WithMany(o => o.reportes).HasForeignKey(o => o.Id);
        }
    }
}
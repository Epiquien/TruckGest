using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class ReportesMap : EntityTypeConfiguration<Reporte>
    {
        public ReportesMap()
        {
            ToTable("Reportes");
            HasKey(o => o.id_reportes);

            //HasRequired(o => o.conductor).WithMany(o => o.reportes).HasForeignKey(o => o.id_reportes);
        }
    }
}
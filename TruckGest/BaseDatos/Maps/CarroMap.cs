using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            ToTable("Carro");
            HasKey(o => o.id_carro);

            //HasRequired(o => o.conductor).WithMany(o => o.carros).HasForeignKey(o => o.id_conductor);

        }
    }
}
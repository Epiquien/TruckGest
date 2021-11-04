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
            HasKey(o => o.Id);

            HasRequired(o => o.conductor);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TruckGest.Models;

namespace TruckGest.BaseDatos.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("usuario");
            HasKey(o => o.id_usuario);

            //HasOptional(o => o.administrador).WithOptionalDependent(o => o.usuario);
            //HasOptional(o => o.conductor).WithOptionalDependent(o => o.usuario);

        }
    }
}
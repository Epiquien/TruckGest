using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Administrador :Trabajador
    {
        public int id_administrador { get; set; }
        
        public int id_usuario { get; set; }

        public List<Conductor> conductores { get; set; }
        //public Usuario usuario { get; set; }

    }
}
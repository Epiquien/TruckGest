using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int typeUser { get; set; }
        

        // Administrador administrador { get; set; }
        //public Conductor conductor { get; set; }
    }
}
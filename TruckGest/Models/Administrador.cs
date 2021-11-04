using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Administrador: Usuario
    {
        public int id_admin { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }

        public List<Conductor> conductores { get; set; }



    }
}
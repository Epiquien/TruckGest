using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public String Correo { get; set; }


    }
}
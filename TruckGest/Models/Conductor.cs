using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Conductor
    {
        public int Id { get; set; }
        public String NombreConductor { get; set; }
        public String ApellidosConductor { get; set; }
        public int Edad{ get; set; }
        public String Licencia { get; set; }
        public int Telefono { get; set; }
        public String Correo { get; set; }
       

    }
}
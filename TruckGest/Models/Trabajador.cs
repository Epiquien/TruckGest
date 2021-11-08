using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public abstract class Trabajador
    {
        public string nombre {get;set;}
        public string apellidos { get; set; }
        public int ?edad { get; set; }
        public bool operativo { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }
        //public float salario { get; set; }
    }
}
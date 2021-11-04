using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Conductor : Usuario
    {
        public int id_conductor { get; set; }
        public string nombreConductor { get; set; }
        public string apellidosConductor { get; set; }
        public int edad{ get; set; }
        public string licencia { get; set; }
        public int telefono { get; set; }
        public string correo { get; set; }

        public int id_administrador { get; set; }
       
        public Administrador administrador { get; set; }
        public List<Carro> carros { get; set; }
        public List<Reporte> reportes { get; set; }

    }
}
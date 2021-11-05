using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Conductor: Trabajador
    {
        public int id_conductor { get; set; }
        public string licencia { get; set; }
        
        public int id_administrador { get; set; }
        public int id_usuario { get; set; }
       
        public Administrador administrador { get; set; }
        public List<Carro> carros { get; set; }
        public List<Reporte> reportes { get; set; }
        //public Usuario usuario { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Reportes
    {
        public int Id { get; set; }
        public  DateTime Dia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public String Descripcion { get; set; }
        public float Costo { get; set; }

        public Conductor conductor { get; set; }


    }
}
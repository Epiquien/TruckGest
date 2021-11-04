using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Reporte
    {
        public int id_reportes { get; set; }
        public  DateTime dia { get; set; }
        public string descripcion { get; set; }
        public float dosto { get; set; }

        public int id_conductor { get; set; }

        public Conductor conductor { get; set; }
    }
}
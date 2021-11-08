using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Carro
    {
        public int id_carro { get; set; }
        public string placa { get; set; }
        public byte[] soat { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public bool operativo { get; set; }
        public DateTime ?soatFechaVencimiento { get; set; }
        public DateTime ?revicionTecnicaFechaVencimiento { get; set; }

        public int id_conductor {get;set;}

        public Conductor conductor { get; set; }

    }
}
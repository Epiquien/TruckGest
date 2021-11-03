using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public String Placa { get; set; }
        public Byte Soat { get; set; }
       public String Tipo { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }

        public DateTime SoatFechaVencimiento { get; set; }

    }
}
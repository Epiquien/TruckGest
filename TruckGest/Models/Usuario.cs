using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public abstract class Usuario
    {
        //public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int typeUser { get; set; }
    }
}
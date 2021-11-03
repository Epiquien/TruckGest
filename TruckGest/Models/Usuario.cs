using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckGest.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int TypeUser { get; set; }
    }
}
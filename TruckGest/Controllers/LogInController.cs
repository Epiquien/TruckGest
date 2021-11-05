using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckGest.BaseDatos;
using TruckGest.Models;

namespace TruckGest.Controllers
{
    public class LogInController : Controller
    {
        private TransportesContext conexiondb;
        public LogInController()
        {
            conexiondb = new TransportesContext();
        }
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingreso(string username, string pass)
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TruckGest.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Camiones()
        {
            return View();
        }
        public ActionResult Conductores()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
    }
}
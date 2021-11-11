using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckGest.BaseDatos;

namespace TruckGest.Controllers
{
    public class ConductorController : Controller
    {
        private TransportesContext conexionDB;
        public ConductorController()
        {
            conexionDB = new TransportesContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult Camiones()
        {
            var conductor_id = conexionDB.conductores.Where(o => o.id_usuario == Convert.ToInt32(Session["idUser"].ToString())).Select(o => o.id_conductor).First();
            return View(conexionDB.carros.Where(o=>o.id_conductor == conductor_id).ToList());
        }
    }
}
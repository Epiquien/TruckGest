using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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
            int id = Convert.ToInt32(Session["idUser"].ToString());
            int idConductor = Convert.ToInt32(Session["idConductor"].ToString());
            return View(conexionDB.carros.Where(o=>o.id_conductor == idConductor).Include(o=>o.conductor).ToList());
        }
    }
}
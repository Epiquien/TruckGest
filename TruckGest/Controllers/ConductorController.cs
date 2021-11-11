using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TruckGest.BaseDatos;
using TruckGest.Models;
using System.Web.Security;

namespace TruckGest.Controllers
{
    public class ConductorController : Controller
    {
        private TransportesContext conexionDB;
        public ConductorController()
        {
            conexionDB = new TransportesContext();
        }
        [Authorize]
        public ActionResult Index()
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }
            return View();
        }
        [Authorize]
        public ActionResult Reportes()
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }
            return View(conexionDB.reportes.ToList());
        }
        [Authorize]
        public ActionResult Camiones()
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }
            int id = Convert.ToInt32(Session["idUser"].ToString());
            int idConductor = Convert.ToInt32(Session["idConductor"].ToString());
            return View(conexionDB.carros.Where(o => o.id_conductor == idConductor).Include(o => o.conductor).ToList());
        }

        public ActionResult addReporte(Reporte reporte)
        {
            if (Session["TypeUser"].ToString() == "2")
            {

                conexionDB.SaveChanges();
                int id = Convert.ToInt32(Session["idUser"].ToString());

                //  int id = Convert.ToInt32(Session["idUser"].ToString());
                // var user_id = conexionDB.usuarios.Where(o => o.userName == newUser.userName).Select(o => o.id_usuario).First();
                var conductor_id = conexionDB.conductores.Where(o => o.id_usuario == id).Select(o => o.id_conductor).First();

                conexionDB.reportes.Add(reporte);
                reporte.id_conductor = conductor_id;

                conexionDB.SaveChanges();
                return RedirectToAction("Reportes");
            }
            return RedirectToAction("LogOff");
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LogIn");
        }

    }
}

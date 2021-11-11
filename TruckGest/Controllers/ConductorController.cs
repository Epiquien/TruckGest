using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckGest.BaseDatos;
using TruckGest.Models;

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
          
            return View(conexionDB.reportes.ToList());
        }
        public ActionResult Camiones()
        {
            var conductor_id = conexionDB.conductores.Where(o => o.id_usuario == Convert.ToInt32(Session["idUser"].ToString())).Select(o => o.id_conductor).First();
            return View(conexionDB.carros.Where(o=>o.id_conductor == conductor_id).ToList());
        }

        public ActionResult addReporte(Reporte reporte )
        {
            if(Session["TypeUser"].ToString() == "2")
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
            return RedirectToAction("Index", "LogIn");
        }

            

        }
    }

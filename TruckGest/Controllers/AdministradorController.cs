using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckGest.BaseDatos;
using TruckGest.Models;
using System.Data.Entity;
using System.Web.Security;

namespace TruckGest.Controllers
{
    public class AdministradorController : Controller
    {
        private TransportesContext conexionDB;
        public AdministradorController()
        {
            conexionDB = new TransportesContext();
        }
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]
        public ActionResult Camiones()
        {
            ViewBag.listConductores = conexionDB.conductores.ToList();
            return View(conexionDB.carros.Include(o=>o.conductor).ToList());
        }

        [Authorize]
        public ActionResult Conductores()
        {
            return View(conexionDB.conductores.ToList());
        }
        public ActionResult addConductor(Conductor conductor, string pass)
        {
            if (Session["TypeUser"].ToString() == "1")//only admins
            {
                var newUser = new Usuario();
                conexionDB.usuarios.Add(newUser);
                newUser.userName = conductor.correo;
                newUser.password = pass;
                newUser.typeUser = 2;
                conexionDB.SaveChanges();
                int id = Convert.ToInt32(Session["idUser"].ToString());

                var user_id = conexionDB.usuarios.Where(o => o.userName == newUser.userName).Select(o=>o.id_usuario).First();
                var admin_id = conexionDB.administradores.Where(o => o.id_usuario == id).Select(o=>o.id_administrador).First();

                conexionDB.conductores.Add(conductor);
                conductor.operativo = true;
                conductor.id_administrador = admin_id;
                conductor.id_usuario = user_id;
                conexionDB.SaveChanges();
                return RedirectToAction("Conductores");
            }
            return RedirectToAction("Index","LogIn");
        }
        [Authorize]
        public ActionResult Reportes()
        {
            return View();
        }
        public ActionResult addCar(Carro car)
        {
           
            if (car.placa != "" && car.tipo != "")
            {
                conexionDB.carros.Add(car);
                car.operativo = true;
                conexionDB.SaveChanges();
            }
            return RedirectToAction("Camiones");
        }
        public ActionResult EditConductor(Conductor conductor)
        {
            var conductorDB = conexionDB.conductores.Where(o => o.id_conductor == conductor.id_conductor).FirstOrDefault();
            conductorDB.nombre = conductor.nombre;
            conductorDB.apellidos = conductor.apellidos;
            conductorDB.edad = conductor.edad;
            conductorDB.telefono = conductor.telefono;
            conductorDB.operativo = conductor.operativo;
            conductorDB.licencia = conductor.licencia;
            conexionDB.SaveChanges();
            return RedirectToAction("Conductores");
        }
        public ActionResult EditModalConductor(string id = "0")
        {
            int idC = Convert.ToInt32(id);
            string[] licTypes = new string[] { "AII-A", "AII-B", "AIII-B", "AIII-A" };
            ViewBag.licTypes = licTypes;
            return View(conexionDB.conductores.Where(o=>o.id_conductor == idC).FirstOrDefault());
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","LogIn");
        }
    }
}
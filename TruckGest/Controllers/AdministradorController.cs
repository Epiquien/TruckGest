using System;
using System.Linq;
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

        #region rutas principales
        [Authorize]
        public ActionResult Index()
        {
            if(Session["TypeUser"].ToString() != "1")
            {
                return RedirectToAction("LogOff");
            }
            return View();
        }

        [Authorize]
        public ActionResult Camiones()
        {
            if (Session["TypeUser"].ToString() != "1")
            {
                return RedirectToAction("LogOff");
            }
            ViewBag.listConductores = conexionDB.conductores.ToList();
            return View(conexionDB.carros.Include(o => o.conductor).ToList());
        }

        [Authorize]
        public ActionResult Conductores()
        {
            if (Session["TypeUser"].ToString() != "1")
            {
                return RedirectToAction("LogOff");
            }
            return View(conexionDB.conductores.ToList());
        }
        [Authorize]
        public ActionResult Reportes()
        {
            if (Session["TypeUser"].ToString() != "1")
            {
                return RedirectToAction("LogOff");
            }
            return View(conexionDB.reportes.Include(o=>o.conductor).ToList());
        }
        #endregion

        #region acciones
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

                var user_id = conexionDB.usuarios.Where(o => o.userName == newUser.userName).Select(o => o.id_usuario).First();
                var admin_id = conexionDB.administradores.Where(o => o.id_usuario == id).Select(o => o.id_administrador).First();

                conexionDB.conductores.Add(conductor);
                conductor.operativo = true;
                conductor.id_administrador = admin_id;
                conductor.id_usuario = user_id;
                conexionDB.SaveChanges();
                return RedirectToAction("Conductores");
            }
            return RedirectToAction("Index", "LogIn");
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
        public ActionResult EditVehiculo(Carro carro)
        {
            var carroDB = conexionDB.carros.Where(o => o.id_carro == carro.id_carro).FirstOrDefault();
            carroDB.placa = carro.placa;
            carroDB.tipo = carro.tipo;
            carroDB.marca = carro.marca;
            carroDB.modelo = carro.modelo;
            carroDB.operativo = carro.operativo;
            carroDB.soatFechaVencimiento = carro.soatFechaVencimiento;
            carroDB.id_conductor = carro.id_conductor;
            conexionDB.SaveChanges();
            return RedirectToAction("Camiones");
        }
        public ActionResult ReportDelete(string id)
        {

            return RedirectToAction("Reportes");
        }
        #endregion

        public ActionResult EditModalConductor(string id = "0")
        {
            int idC = Convert.ToInt32(id);
            string[] licTypes = new string[] { "AII-A", "AII-B", "AIII-B", "AIII-A" };
            ViewBag.licTypes = licTypes;
            return View(conexionDB.conductores.Where(o => o.id_conductor == idC).FirstOrDefault());
        }
        public ActionResult EditModalVehiculo(string id = "0")
        {
            int idC = Convert.ToInt32(id);
            string[] carTypes = new string[] { "Camion", "Camioneta", "Combi", "Furgoneta", "Sprinter" };
            ViewBag.carTypes = carTypes;
            ViewBag.listConductores = conexionDB.conductores.ToList();
            var carro = conexionDB.carros.Where(o => o.id_carro == idC).Include(o => o.conductor).FirstOrDefault();
            string month,day;
            if (carro.soatFechaVencimiento.Value.Month.ToString().Length == 1)
            {
                month = '0' + carro.soatFechaVencimiento.Value.Month.ToString();
            }
            else
            {
                month = carro.soatFechaVencimiento.Value.Month.ToString();
            }
            if (carro.soatFechaVencimiento.Value.Day.ToString().Length == 1)
            {
                day = '0' + carro.soatFechaVencimiento.Value.Day.ToString();
            }
            else
            {
                day = carro.soatFechaVencimiento.Value.Day.ToString();
            }
            ViewData["date"] = carro.soatFechaVencimiento.Value.Year.ToString()+'-'+month+'-'+day;
            return View(carro);
        }
        public ActionResult reportDeleted(string id_reportes)
        {
            int idReport = Convert.ToInt32(id_reportes);
            var report = conexionDB.reportes.Where(o => o.id_reportes == idReport).FirstOrDefault();
            conexionDB.reportes.Remove(report);
            conexionDB.SaveChanges();
            return RedirectToAction("Reportes");
        }
        public ActionResult LogOff()
        {
            Session["idUser"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LogIn");
        }
    }
}
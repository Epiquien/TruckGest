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
            var user = conexiondb.usuarios.Where(o => o.userName == username && o.password == pass).FirstOrDefault();
            if (user != null)
            {
                Session["idUser"] = user.id_usuario;
                Session["TypeUser"] = user.typeUser.ToString();
                switch (user.typeUser)
                {
                    case 1: //administrador
                        return RedirectToAction("Index", "Administrador");
                    case 2: //conductor
                        return RedirectToAction("Index", "Conductor");
                    default:
                        break;
                }
            }
            return View("errorUser");
        }
    }
}
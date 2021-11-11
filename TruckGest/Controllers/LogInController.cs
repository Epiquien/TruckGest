using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TruckGest.BaseDatos;

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
                FormsAuthentication.SetAuthCookie(Session["idUser"].ToString(), false);
                switch (user.typeUser)
                {
                    case 1: //administrador
                        
                         return RedirectToAction("Index", "Administrador");
                    case 2: //conductor
                        var conductor = conexiondb.conductores.Where(o => o.id_usuario == user.id_usuario).First();
                        if (conductor.operativo)
                        {
                            Session["nameTrabajador"] = conductor.nombre +' '+ conductor.apellidos;
                            Session["idConductor"] = conductor.id_conductor;
                            return RedirectToAction("Index", "Conductor");
                        }
                        break;
                    default:
                        break;
                }
            }
            return View("errorUser");
        }
    }
}
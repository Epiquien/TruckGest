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
        private gesTruckEntities2 conexionDB2;
        public ConductorController()
        {
            conexionDB = new TransportesContext();
            conexionDB2 = new gesTruckEntities2();
        }
        [Authorize]
        public ActionResult Index()
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }
            int id = Convert.ToInt32(Session["idConductor"].ToString());
            ViewData["nReports"] = conexionDB2.nReportsConductor(id).FirstOrDefault().ToString();
            ViewData["nReportsDay"] = conexionDB2.nReportToDay(id).FirstOrDefault().ToString();
            ViewData["spendConductor"] = conexionDB2.getSpendConductor(id).FirstOrDefault().ToString();
            ViewData["spendConductorToDay"] = conexionDB2.getSpendConductorToDay(id).FirstOrDefault().ToString();
            return View();
        }
        [Authorize]
        public ActionResult Reportes()
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }
            int idConductor = Convert.ToInt32(Session["idConductor"].ToString());
            return View(conexionDB.reportes.Where(o => o.id_conductor == idConductor).ToList());
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
        [Authorize]
        public ActionResult addReporte(Reporte reporte)
        {
            if (Session["TypeUser"].ToString() != "2")
            {
                return RedirectToAction("LogOff");
            }

            int id = Convert.ToInt32(Session["idUser"].ToString());
            var conductor_id = conexionDB.conductores.Where(o => o.id_usuario == id).Select(o => o.id_conductor).First();

            conexionDB.reportes.Add(reporte);
            reporte.id_conductor = conductor_id;

            conexionDB.SaveChanges();
            return RedirectToAction("Reportes");
        }
        public ActionResult updateReport(Reporte report)
        {
            var reporte = conexionDB.reportes.Where(o => o.id_reportes == report.id_reportes).First();
            reporte.dia = report.dia;
            reporte.descripcion = report.descripcion;
            reporte.dosto = report.dosto;
            conexionDB.SaveChanges();
            return RedirectToAction("Reportes");
        }
        public ActionResult EditModalReport(string id)
        {
            int id_report = Convert.ToInt32(id);
            var report = conexionDB.reportes.Where(o => o.id_reportes == id_report).FirstOrDefault();
            string month, day;
            if (report.dia.Month.ToString().Length == 1)
            {
                month = '0' + report.dia.Month.ToString();
            }
            else
            {
                month = report.dia.Month.ToString();
            }
            if (report.dia.Day.ToString().Length == 1)
            {
                day = '0' + report.dia.Day.ToString();
            }
            else
            {
                day = report.dia.Day.ToString();
            }
            ViewData["date"] = report.dia.Year.ToString() + '-' + month + '-' + day;
            return View(report);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LogIn");
        }

    }
}

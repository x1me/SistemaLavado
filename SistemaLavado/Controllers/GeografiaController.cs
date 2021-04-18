using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;
using SistemaLavado.Clases;

namespace SistemaLavado.Controllers
{
    public class GeografiaController : Controller
    {
        // GET: Geografia
        sistemacontrolEntities db = new sistemacontrolEntities();

        public ActionResult Provincia()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            return View();
        }

        public ActionResult RetornaProvincia()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            var provincia = db.pa_ProvinciaSelect(null, -1).ToList();
            return Json(provincia, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Canton()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            return View();
        }

        public ActionResult RetornaCanton()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            var canton = db.pa_CantonSelect(null, null).ToList();
            var datos = (from i in canton
                         select new
                         {
                             nombre = i.nombre,
                             provincia = db.Provincia.Where(e => e.id_Provincia == i.id_Provincia).Select(e => e.nombre).First(),
                             usuarioCrea = i.usuarioCrea,
                             ususarioModifica = i.usuarioModifica,
                             fechaCrea = i.fechaCrea,
                             fechaModifica = i.fechaModifica,
                             vc_Estado = i.vc_Estado
                         }
                        ).ToList();

            return Json(datos, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Distrito()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            return View();
        }

        public ActionResult RetornaDistrito()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            var distrito = db.pa_DistritoSelect(-1).ToList();
            var datos = (from i in distrito
                         select new
                         {
                             nombre = i.nombre,
                             canton = db.Canton.Where(e => e.id_Canton == i.id_Canton).Select(e => e.nombre).First(),
                             usuarioCrea = i.usuarioCrea,
                             ususarioModifica = i.usuarioModifica,
                             fechaCrea = i.fechaCrea,
                             fechaModifica = i.fechaModifica,
                             vc_Estado = i.vc_Estado
                         }
                         ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);

        }
    }
}

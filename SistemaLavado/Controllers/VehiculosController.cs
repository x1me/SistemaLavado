using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;
namespace SistemaLavado.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: Vehiculos
        sistemacontrolEntities bd = new sistemacontrolEntities();
        public ActionResult Index()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = Session["role"] as string;
            return View("ListaVehiculo");
        }
        [HttpGet, ActionName("listar")]
        public ActionResult ListaVehiculo()
        {  
            var Vehiculos = bd.pa_VehiculoRetorna().ToList();
            var datos = (from i in Vehiculos
                         select new
                         {
                             //tipo = bd.TipoVehiculo.Where(e => e. == i.tipo).Select(e => e.tipo).First(),
                             
                             marca = bd.MarcaVehiculo.Where(e => e.id_codigoMarcaV == i.marca).Select(e => e.tipo).First(),
                         }
                        ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
    }
}
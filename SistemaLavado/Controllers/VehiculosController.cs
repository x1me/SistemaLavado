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
        { // crear pa vehiculo y cambiar id por nombres
            var Vehiculos = bd.pa_v().ToList();
            var datos = (from i in Marca
                         select new
                         {
                             tipo = bd.TipoVehiculo.Where(e => e.id_codigoTV == i.tipo).Select(e => e.tipo).First(),
                             id_codigoMarcaV = i.id_codigoMarcaV,
                             codigo = i.codigo,
                             fabricante = bd.Fabricante.Where(e => e.id_codfabricante == i.fabricante).Select(e => e.pais).First(),
                         }
                        ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }
    }
}
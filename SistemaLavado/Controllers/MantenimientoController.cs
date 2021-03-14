using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class MantenimientoController : Controller
    {
        sistemadecontrolEntities ModeloBD = new sistemadecontrolEntities();
        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaFabricante()
        {
            List<pa_fabricanteSelect_Result> ModeloVista = this.ModeloBD.pa_fabricanteSelect(null,null).ToList();
            return View(ModeloVista);
        }
    }
}
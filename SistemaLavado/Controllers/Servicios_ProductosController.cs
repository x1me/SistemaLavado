using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class Servicios_ProductosController : Controller
    {
        sistemacontrolEntities bd = new sistemacontrolEntities();
        // GET: Servicios_Productos
        public ActionResult Index()
        {
            ViewBag.tipo = Session["role"] as string;
            var ServyProd = bd.pa_ServicioProductoSelect(1).ToList();
            return View();
        }
    }
}
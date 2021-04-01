using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class MarcasDeVehiculoController : Controller
    {
        sistemacontrolEntities bd = new sistemacontrolEntities();
        // GET: MarcasDeVehiculo
        public ActionResult ListaMarcas()
        {
            ViewBag.tipo = Session["role"] as string;
            var MarcaVehiculo = bd.pa_Marca_Vehiculo_Retorna().ToList();
            var modelo = (from i in MarcaVehiculo
                          select new
                          {
                              id = i.id_codigoMarcaV,
                              codigo = i.codigo,
                              tipo = bd.pa_TipoVehiculoRetorna(i.tipo, "").FirstOrDefault().tipo,
                              fabricante = bd.pa_fabricanteSelect(i.fabricante, "").FirstOrDefault().pais,
                          }).ToList();
            return View(modelo);
        }

        [HttpGet, ActionName("agregar")]
        public ActionResult EditarAgregar(int? id)
        {
            // Esto no funciona
            var modelo = new MarcaVehiculo();
            if (id > 0)
            {
                var marca = bd.MarcaVehiculo.Where(e => e.id_codigoMarcaV == id).Select(e => e).FirstOrDefault();
                modelo.codigo = marca.codigo;
                modelo.fabricante = marca.fabricante;
                modelo.tipo = marca.tipo;
                modelo.id_codigoMarcaV = marca.id_codigoMarcaV;
            }
            return View(modelo);
        }

        [HttpPost, ActionName("agregar")]
        public ActionResult EditarAgregar(MarcaVehiculo modelo)
        {
            try
            {
                string mensaje = "Registro {} correctamente";
                // Aun sin modificar?
                bd.MarcaVehiculo.Add(modelo);
                int resultado = bd.SaveChanges();
                if (resultado == 0) mensaje = mensaje.Replace("{}", "insertado");

                ViewData["estado"] = new Mensaje() { confirmacion = mensaje, estado = resultado > 0 };
                return RedirectToAction("ListaMarcas");
            }
            catch (Exception error)
            {
                ViewData["error"] = error.Message;
                return null;
            }
        }

    }
}
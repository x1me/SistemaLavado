using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class MantenimientoFabricanteController : Controller
    {
        sistemacontrolEntities bd = new sistemacontrolEntities();
        public ActionResult Index()
        {
            return View("ListaFabricante");
        }

        [HttpGet, ActionName("listar")]
        public ActionResult ListaFabricante()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_FabricanteRetorna_Result> ModeloVista = this.bd.pa_FabricanteRetorna().ToList();
            return Json(ModeloVista, JsonRequestBehavior.AllowGet);
        }
        [ActionName("agregaroeditar")]
        public ActionResult InsertarAgregarFabricante(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            try
            {
                Fabricante model = new Fabricante();
                List<pa_FabricanteRetorna_Result> ModeloVista = this.bd.pa_FabricanteRetorna().ToList();
                if (id != null)
                {
                    var fabricante = bd.pa_fabricanteSelect(id, "").FirstOrDefault();
                    model.codigo = fabricante.codigo;
                    model.pais = fabricante.pais;
                    model.id_codfabricante = fabricante.id_codfabricante;
                }
                return View("InsertarFabricante", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ActionName("agregaroeditar")]
        [HttpPost]
        public ActionResult InsertarAgregarFabricante(Fabricante fabricante)
        {
            ViewBag.tipo = Session["role"] as string;
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {

                if (fabricante.id_codfabricante > 0)
                {
                    cantRegistrosAfectados = bd.pa_FabricanteModifica(fabricante.id_codfabricante,
                                                                        fabricante.codigo, fabricante.pais);
                    resultado = "Registro modificado correctamente";
                    
                }
                else
                {
                    if (!bd.Fabricante.Any(e => e.codigo == fabricante.codigo))
                    {

                        cantRegistrosAfectados = this.bd.pa_fabricanteInsert(fabricante.codigo, fabricante.pais);
                        resultado = "Registro insertado correctamente";
                    }
                    else
                    {
                        resultado = "El código ya existe";
                    }
                    return RedirectToAction("Index");
                }

            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            finally
            {
                resultado = (resultado.Length == 0) ? "Error al realizar la operación!" : resultado;
                TempData["mensaje"] = resultado;
                TempData["estado"] = cantRegistrosAfectados > 0;
            }
            return Json(resultado);
        }
        [HttpGet]
        public ActionResult EliminaFabricante(Fabricante fabricante)
        {
            ViewBag.tipo = Session["role"] as string;
             int registroAfectado = 0;
            string resultado = "";         
            try
            {
                if (fabricante.id_codfabricante > 0)
                {
                    registroAfectado = bd.pa_fabricanteDelete(fabricante.id_codfabricante);
                    resultado = "Registro eliminado correctamente.";
                }
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                resultado = (resultado.Length == 0) ? "Error al realizar la operación!" : resultado;
                TempData["mensaje"] = resultado;
                TempData["estado"] = registroAfectado > 0;
            }
            return Json(resultado);
        }

    }
}

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
        // GET: Mantenimiento

        public ActionResult ListaFabricante()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_FabricanteRetorna_Result> ModeloVista = this.bd.pa_FabricanteRetorna().ToList();
            return View(ModeloVista);
        }

        [ActionName("agregaroeditar")]
        [HttpGet]
        public ActionResult InsertarAgregarFabricante(int? id)
        {
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
                    cantRegistrosAfectados = this.bd.pa_fabricanteInsert(fabricante.codigo, fabricante.pais);
                    resultado = "Registro insertado correctamente";
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
            return RedirectToAction("ListaFabricante");
        }

        [HttpGet]
        public ActionResult EliminaFabricante(int id)
        {
            ViewBag.tipo = Session["role"] as string;
            string resultado = "Error al eliminar el registro!";
            int registroAfectado = 0;

            try
            {
                registroAfectado = bd.pa_fabricanteDelete(id);
                if (registroAfectado > 0)
                {
                    resultado = "Registro eliminado correctamente.";
                }
                return RedirectToAction("ListaFabricante");
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = registroAfectado > 0;
            }
        }




    }
}

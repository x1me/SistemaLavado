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
        public ActionResult Index()
        {
            return View("ListaMarca");
        }

        [HttpGet, ActionName("listar")]
        public ActionResult ListaMarca()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_Marca_Vehiculo_Retorna_Result> ModeloVista = this.bd.pa_Marca_Vehiculo_Retorna().ToList();
            return Json(ModeloVista, JsonRequestBehavior.AllowGet);
        }

        [ActionName("agregaroeditar")]
        [HttpGet]
        public ActionResult InsertarAgregarMarca(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            try
            {
                Fabricante model = new Fabricante();
                List<pa_Marca_Vehiculo_Retorna_Result> ModeloVista = this.bd.pa_Marca_Vehiculo_Retorna().ToList();
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


    }
}
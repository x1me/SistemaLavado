using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class MantenimientoTipoDeVehiculosController : Controller
    {
        sistemacontrolEntities bd = new sistemacontrolEntities();
        // GET: MantenimientoTipoDeVehiculos
        public ActionResult Index()
        {
            return View("ListaTipoVehiculo");
        }
        [HttpGet, ActionName("listar")]
        public ActionResult ListaTipoVehiculo()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_TipoVehiculoRetorna_Result> ModeloVista = this.bd.pa_TipoVehiculoRetorna(null,null).ToList();
            return Json(ModeloVista, JsonRequestBehavior.AllowGet);
        }

        [ActionName("agregaroeditar")]
        [HttpGet]
        public ActionResult InsertarAgregarTipoVehiculo(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            try
            {
                TipoVehiculo model = new TipoVehiculo();
                List<pa_TipoVehiculoRetorna_Result> ModeloVista = this.bd.pa_TipoVehiculoRetorna(null,null).ToList();
                if (id != null)
                {
                    var TipoVehiculo = bd.pa_TipoVehiculoRetorna(id, "").FirstOrDefault();
                    model.codigo = TipoVehiculo.codigo;
                    model.tipo = TipoVehiculo.tipo;
                    model.id_codigoTV = TipoVehiculo.id_codigoTV;
                }
                return View("InsertarAgregarTipoVehiculo", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ActionName("agregaroeditar")]
        [HttpPost]
        public ActionResult InsertarAgregarTipoVehiculo(TipoVehiculo TipoVehiculo)
        {
            ViewBag.tipo = Session["role"] as string;
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                if (TipoVehiculo.id_codigoTV > 0)
                {
                    cantRegistrosAfectados = bd.pa_TipoVehiculoModifica(TipoVehiculo.id_codigoTV,
                                                                        TipoVehiculo.codigo, TipoVehiculo.tipo);
                    resultado = "Registro modificado correctamente";
                }
                else
                {
                    cantRegistrosAfectados = this.bd.pa_TipoVehiculoInsert(TipoVehiculo.codigo, TipoVehiculo.tipo);
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
            return RedirectToAction("ListaTipoVehiculo");
        }


        [HttpGet]
        public ActionResult EliminaTipoVehiculo(int id)
        {
            ViewBag.tipo = Session["role"] as string;
            string resultado = "Error al eliminar el registro!";
            int registroAfectado = 0;

            try
            {
                registroAfectado = bd.pa_TipoVehiculoDelete(id);
                if (registroAfectado > 0)
                {
                    resultado = "Registro eliminado correctamente.";
                }
                return RedirectToAction("ListaTipoVehiculo");
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
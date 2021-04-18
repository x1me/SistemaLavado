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
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = Session["role"] as string;
            return View("ListaTipoVehiculo");
        }
        [HttpGet, ActionName("listar")]
        public ActionResult ListaTipoVehiculo()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_TTipo_VehiculoRetorna_Result> ModeloVista = this.bd.pa_TTipo_VehiculoRetorna().ToList();
            return Json(ModeloVista, JsonRequestBehavior.AllowGet);
        }

        [ActionName("agregaroeditar")]
        public ActionResult InsertarAgregarTipoVehiculo(int? id)
        {
            ViewBag.tipo = Session["role"] as string;

            try
            {
                TipoVehiculo model = new TipoVehiculo();
                List<pa_TTipo_VehiculoRetorna_Result> ModeloVista = this.bd.pa_TTipo_VehiculoRetorna().ToList();
                if (id != null)
                {
                    var TipoVehiculo = bd.pa_TipoVehiculoSelect(id, "").FirstOrDefault();
                    model.codigo = TipoVehiculo.codigo;
                    model.tipo = TipoVehiculo.tipo;
                    model.id_codigoTV = TipoVehiculo.id_codigoTV;
                }
                return View("InsertarTipoVehiculo", model);
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
                    if (!bd.Fabricante.Any(e => e.codigo == TipoVehiculo.codigo))
                    {

                        cantRegistrosAfectados = this.bd.pa_TipoVehiculoInsert(TipoVehiculo.codigo, TipoVehiculo.tipo);
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
        public ActionResult EliminaTipoVehiculo(TipoVehiculo TipoVehiculo)
        {
            ViewBag.tipo = Session["role"] as string;
            string resultado = "Error al eliminar el registro!";
            int registroAfectado = 0;

            try
            {

                if (TipoVehiculo.id_codigoTV > 0)
                {
                    registroAfectado = bd.pa_TipoVehiculoDelete(TipoVehiculo.id_codigoTV);
                    resultado = "Registro eliminado correctamente.";
                }
            }
            catch (Exception e)
            {
                throw;
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
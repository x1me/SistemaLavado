using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class ClienteVEController : Controller
    {
        sistemacontrolEntities bd = new sistemacontrolEntities();
        public ActionResult Index()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = Session["role"] as string;
            return View("ListaClienteVehiculo");
        }

        [HttpGet, ActionName("listar")]
        public ActionResult ListaClienteVehiculo()
        {
            ViewBag.tipo = Session["role"] as string;
            var VehiculoClientes = bd.pa_VehiculoClienteRetorna().ToList();
            var datos = (from i in VehiculoClientes
                         select new
                         {
                             codigoCliente = bd.Cliente.Where(e => e.id_cliente == i.codigoCliente).Select(e => e.nombre).First(),
                             codigoVehiculo = bd.Vehiculo.Where(e => e.placa == i.codigoVehiculo).Select(e => e.placa).First(),
                         }
                        ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        [ActionName("agregaroeditar")]
        public ActionResult InsertarAgregar(int? id)
        {

            ViewBag.tipo = Session["role"] as string;
            var reg = bd.pa_VehiculoClienteRetorna().ToList();
            ViewBag.listacodigoCliente = (from i in bd.Cliente
                                   select new ListaClienteVe()
                                   {
                                       codigoCliente = i.id_cliente,
                                       nombrecliente = i.nombre
                                   }).ToList();
            ViewBag.listacodigovehiculo = (from i in bd.Vehiculo
                                         select new ListaVehiculoCl()
                                         {
                                             codigoVehiculo = i.placa,
                                         }).ToList();
            try
            {
                VehiculoCliente model = new VehiculoCliente();
                List<pa_VehiculoClienteRetorna_Result> ModeloVista = this.bd.pa_VehiculoClienteRetorna().ToList();
                if (id != null)
                {
                    var VehiculoCliente = bd.pa_VehiculoClienteRetorna().FirstOrDefault();
                    model.codigoCliente = VehiculoCliente.codigoCliente;
                    model.codigoVehiculo = VehiculoCliente.codigoVehiculo;
                }
                return View("InsertaClienteVehiculo", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ActionName("agregaroeditar")]
        [HttpPost]
        public ActionResult InsertarAgregarClienteVE(VehiculoCliente VehiculoCliente)
        {
            ViewBag.tipo = Session["role"] as string;
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                if (VehiculoCliente.codigoCliente > 0)
                {
                    cantRegistrosAfectados = bd.pa_VehiculoclienteModifica(VehiculoCliente.codigoCliente,
                                                                        VehiculoCliente.codigoVehiculo);
                    resultado = "Registro modificado correctamente";
                }
                else
                {
                    if (!bd.VehiculoCliente.Any(e => e.codigoCliente == VehiculoCliente.codigoCliente))
                    {

                        cantRegistrosAfectados = this.bd.pa_VehiculoClienteInsert(VehiculoCliente.codigoCliente, VehiculoCliente.codigoVehiculo);
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
        public ActionResult Elimina(VehiculoCliente VehiculoCliente)
        {
            ViewBag.tipo = Session["role"] as string;
            int registroAfectado = 0;
            string resultado = "";
            try
            {
                if (VehiculoCliente.codigoCliente > 0)
                {
                    registroAfectado = bd.pa_VehiculoclienteDelete(VehiculoCliente.codigoCliente, VehiculoCliente.codigoVehiculo);
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
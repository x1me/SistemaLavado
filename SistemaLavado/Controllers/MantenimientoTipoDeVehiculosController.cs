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
            return View();
        }
        public ActionResult ListaTipoVehiculo()
        {
            ViewBag.tipo = Session["role"] as string;            
           var TipoVehiculo = bd.pa_TipoVehiculoRetorna(1,"nuevo").ToList();/*nuevo*/
            return View();
        }
        public ActionResult InsertarTipoVehiculo()
        {
            ViewBag.tipo = Session["role"] as string;
            List<pa_TipoVehiculoRetorna_Result> ModeloVista = this.bd.pa_TipoVehiculoRetorna(1,"nuevo").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult InsertarTipoVehiculo(pa_TipoVehiculoRetorna_Result objModeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.bd.pa_TipoVehiculoInsert(
                        objModeloVista.codigo,
                        objModeloVista.tipo);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";
                }
                else
                {
                    resultado += ".No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View();
        }

        /// revisar el modificar y eliminar no me funciona

        public ActionResult ModificarTipoVehiculo(int id_codigoTV)
        {
            pa_TipoVehiculo_Retorna_ID_Result ModeloVista = new pa_TipoVehiculo_Retorna_ID_Result();
            ModeloVista = this.bd.pa_TipoVehiculo_Retorna_ID(id_codigoTV).FirstOrDefault();
            return View(ModeloVista);
        }

        [HttpPost]
        public ActionResult ModificarTipoVehiculo(pa_TipoVehiculo_Retorna_ID_Result objModeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.bd.pa_TipoVehiculoModifica(
                        objModeloVista.id_codigoTV,
                        objModeloVista.codigo,
                        objModeloVista.tipo);
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";
                }
                else
                {
                    resultado += ".No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View();
        }
        public ActionResult EliminarTipoVehiculo(int id_codigoTV)
        {
            pa_TipoVehiculo_Retorna_ID_Result ModeloVista = new pa_TipoVehiculo_Retorna_ID_Result();
            ModeloVista = this.bd.pa_TipoVehiculo_Retorna_ID(id_codigoTV).FirstOrDefault();
            return View(ModeloVista);
        }

        [HttpPost]
        public ActionResult EliminarTipoVehiculo(pa_TipoVehiculo_Retorna_ID_Result objModeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.bd.pa_TipoVehiculoDelete(
                        objModeloVista.id_codigoTV
                                );
            }
            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }

            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado = "Registro insertado";
                }
                else
                {
                    resultado += ".No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View();
        }
    }
}
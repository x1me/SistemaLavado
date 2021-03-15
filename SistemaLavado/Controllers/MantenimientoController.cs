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
            List<pa_RetornaFabricante_Result> ModeloVista = this.ModeloBD.pa_RetornaFabricante().ToList();
            return View(ModeloVista);
        }

        public ActionResult InsertarFabricante()
        {
            List<pa_RetornaFabricante_Result> ModeloVista = this.ModeloBD.pa_RetornaFabricante().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult InsertarFabricante(pa_RetornaFabricante_Result objModeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =
                    this.ModeloBD.pa_fabricanteInsert(
                        objModeloVista.codigo,
                        objModeloVista.pais);
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
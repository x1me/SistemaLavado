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
        sistemacontrolEntities ModeloBD = new sistemacontrolEntities();
        // GET: Mantenimiento
        public ActionResult Index()
        {                
                return View();
        }

        public ActionResult ListaFabricante()
        {
            List<pa_FabricanteRetorna_Result> ModeloVista = this.ModeloBD.pa_FabricanteRetorna().ToList();
            return View(ModeloVista);
        }


        public ActionResult InsertarFabricante()
        {
            List<pa_FabricanteRetorna_Result> ModeloVista = this.ModeloBD.pa_FabricanteRetorna().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult InsertarFabricante(pa_FabricanteRetorna_Result objModeloVista)
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

        public ActionResult ModificaFabricante(int id_codfabricante)
        {
            pa_Fabricante_Retorna_ID_Result ModeloVista = new pa_Fabricante_Retorna_ID_Result();
            ModeloVista = this.ModeloBD.pa_Fabricante_Retorna_ID(id_codfabricante).FirstOrDefault();
            return View(ModeloVista);
        }

        [HttpPost]
        public ActionResult ModificaFabricante(pa_Fabricante_Retorna_ID_Result objModeloVista)
        {
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados =this.ModeloBD.pa_FabricanteModifica(
                        objModeloVista.id_codfabricante,
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
                
                    resultado = "Registro modificado";
                
                else
                
                    resultado += ".No se pudo insertar";
                
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View(objModeloVista);
        }
    }
}
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
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = Session["role"] as string;
            return View("ListaMarcas");
        }

        [HttpGet, ActionName("listar")]
        public ActionResult ListaMarca()
        {
            ViewBag.tipo = Session["role"] as string;
            //List<pa_Marca_Vehiculo_Retorna_Result> Marca = this.bd.pa_Marca_Vehiculo_Retorna().ToList();
            var Marca = bd.pa_Marca_Vehiculo_Retorna().ToList();
            var datos = (from i in Marca
                         select new
                         {
                             tipo = bd.TipoVehiculo.Where(e => e.id_codigoTV == i.tipo).Select(e => e.tipo).First(),
                             id_codigoMarcaV = i.id_codigoMarcaV,
                             codigo = i.codigo,
                             fabricante = bd.Fabricante.Where(e => e.id_codfabricante == i.fabricante).Select(e => e.pais).First(),
                             nombre_marca = i.nombre_marca,
                         }
                        ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        [ActionName("agregaroeditar")]
        public ActionResult InsertarAgregarMarca(int? id)
        {

            ViewBag.tipo = Session["role"] as string;
            var reg = bd.pa_Marca_VehiculoSelect(null).ToList();
            ViewBag.lista_tipos = (from i in bd.TipoVehiculo
                                   select new ListaTipoV()
                                   {
                                       id_tipo = i.id_codigoTV,
                                       tipo_nombre = i.tipo,
                                       
                                   }).ToList();
            ViewBag.lista_fabricantes = (from i in bd.Fabricante
                                         select new ListaFabricante()
                                         {
                                             id__fabricante = i.id_codfabricante,
                                             fabricante_nombre = i.pais,
                                         }).ToList();
           
            try
            {
                MarcaVehiculo model = new MarcaVehiculo();
                List<pa_Marca_Vehiculo_Retorna_Result> ModeloVista = this.bd.pa_Marca_Vehiculo_Retorna().ToList();
                if (id != null)
                {
                    var marcaVehiculo = bd.pa_Marca_VehiculoSelect(id).FirstOrDefault();
                    model.id_codigoMarcaV = marcaVehiculo.id_codigoMarcaV;
                    model.codigo = marcaVehiculo.codigo;
                    model.tipo = marcaVehiculo.tipo;
                    model.fabricante = marcaVehiculo.fabricante;
                    model.nombre_marca = marcaVehiculo.nombre_marca;
                }
                return View("InsertaMarca", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ActionName("agregaroeditar")]
        [HttpPost]
        public ActionResult InsertarAgregarMarca(MarcaVehiculo MarcaVehiculo)
        {
            ViewBag.tipo = Session["role"] as string;
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                if (MarcaVehiculo.id_codigoMarcaV > 0)
                {
                    cantRegistrosAfectados = bd.pa_Marca_VehiculoUpdate(MarcaVehiculo.id_codigoMarcaV,
                                                                        MarcaVehiculo.codigo, MarcaVehiculo.fabricante, MarcaVehiculo.tipo, MarcaVehiculo.nombre_marca);
                    resultado = "Registro modificado correctamente";
                }
                else
                {
                    if (!bd.MarcaVehiculo.Any(e => e.codigo == MarcaVehiculo.codigo))
                    {

                        cantRegistrosAfectados = this.bd.pa_Marca_VehiculoInsert(MarcaVehiculo.codigo, MarcaVehiculo.fabricante, MarcaVehiculo.tipo, MarcaVehiculo.nombre_marca);
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
        public ActionResult Elimina(MarcaVehiculo MarcaVehiculo)
        {
            ViewBag.tipo = Session["role"] as string;
            int registroAfectado = 0;
            string resultado = "";
            try
            {
                if (MarcaVehiculo.id_codigoMarcaV > 0)
                {
                    registroAfectado = bd.pa_Marca_VehiculoDelete(MarcaVehiculo.id_codigoMarcaV);
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

        [HttpGet]
        public JsonResult RetornaTipos()
        {
            var tipos = bd.pa_TipoVehiculoSelect(null,"").ToList();
            return Json(tipos, JsonRequestBehavior.AllowGet);
        }

    }
}
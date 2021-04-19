using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;
namespace SistemaLavado.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: Vehiculos
        sistemacontrolEntities bd = new sistemacontrolEntities();
        public ActionResult Index()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = Session["role"] as string;
            return View("ListaVehiculo");
        }
        [HttpGet, ActionName("listar")]
        public ActionResult ListaVehiculo()
        {
            var Vehiculos = bd.pa_VehiculoRetorna().ToList();
            var datos = (from i in Vehiculos
                         select new
                         {
                             id = i.id_vehiculo,
                             placa = i.placa,
                             marca_nombre = bd.MarcaVehiculo.Where(e => e.id_codigoMarcaV == i.marca).First().nombre_marca,
                             numero_ruedas = i.numeroRuedas,
                             numero_puertas = i.numeroPuertas,
                             tipo_nombre = bd.TipoVehiculo.Where(e => e.id_codigoTV == i.tipo).First().tipo,
                         }
                        ).ToList();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }


        [ActionName("agregaroeditar")]
        public ActionResult InsertarVehiculo(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            ViewBag.tipos = bd.pa_TipoVehiculoSelect(null, "").ToList();
            ViewBag.marcas = bd.pa_Marca_VehiculoSelect(null).ToList();
            try
            {
                Vehiculo model = new Vehiculo();
                var ModeloVista = this.bd.pa_VehiculoRetorna().ToList();
                if (id != null)
                {
                    var Vh = bd.pa_VehiculoSelect(null).FirstOrDefault();
                    model.id_vehiculo = Vh.id_vehiculo;
                    model.placa = Vh.placa;
                    model.tipo = Vh.tipo;
                    model.marca = Vh.marca;
                    model.numeroPuertas = Vh.numeroPuertas;
                    model.numeroRuedas = Vh.numeroRuedas;

                }
                return View("InsertarVehiculo", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [ActionName("agregaroeditar")]
        [HttpPost]
        public ActionResult InsertarVehiculo(Vehiculo vehiculo)
        {
            ViewBag.tipo = Session["role"] as string;
            ///Variable que registra la cantidad de registros afectados
            ///si un procedimiento que ejecuta insert, update o delete 
            ///no afecta registros implica que hubo un error
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {

                if (vehiculo.id_vehiculo > 0)
                {
                    cantRegistrosAfectados = bd.pa_VehiculoModifica(vehiculo.id_vehiculo, vehiculo.placa,
                           vehiculo.tipo, vehiculo.marca, vehiculo.numeroPuertas, vehiculo.numeroRuedas);
                    resultado = "Registro modificado correctamente";

                }
                else
                {
                    if (!bd.Vehiculo.Any(e => e.id_vehiculo == vehiculo.id_vehiculo))
                    {

                        cantRegistrosAfectados = this.bd.pa_VehiculoInsert(vehiculo.placa,
                           vehiculo.tipo, vehiculo.marca, vehiculo.numeroPuertas, vehiculo.numeroRuedas);
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
    }
}
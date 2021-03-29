using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class ClientesController : Controller
    {

        sistemacontrolEntities db = new sistemacontrolEntities();
        [HttpGet, ActionName("index")]
        public ActionResult ListaClientes()
        {
            ViewBag.tipo = Session["role"] as string;
            var cliente = db.pa_ClienteSelect(null).ToList();
            return View("ListaClientes", cliente);
            
        }

        [ActionName("agregar")]
        [HttpGet]
        public ActionResult AgregarNuevoCliente(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            Cliente cliente = new Cliente();
            ViewBag.provincias = db.pa_ProvinciaSelect(null, null).ToList();
            ViewBag.cantones = db.pa_CantonSelect(null, null).ToList();
            ViewBag.distritos = db.pa_DistritoSelect(null).ToList();
            if (id > 0)
            {
                cliente = db.Cliente.Where(e => e.id_cliente == id).FirstOrDefault();
            }
            return View("AgregarNuevoCliente", cliente);
        }

        [ActionName("modificar")]
        [HttpPost]
        public ActionResult AgregarNuevoCliente(Cliente model)
        {
            try
            {
                int resultado = 0, existe = 0;
                string mensaje = "Registro insertado correctamente";
                if (model.id_cliente > 0)
                {
                    resultado = db.pa_ClienteUpdate(model.id_cliente, model.cedula,
                                                    model.genero, model.nombre, model.correo,
                                                    model.provincia, model.canton, model.distrito);
                    mensaje = "Registro modificado";
                }
                else
                {
                    // Verificar si el cliente a insertar existe.
                    existe = db.Cliente.Where(e => e.cedula == model.cedula).Count();
                    if (existe == 0)
                    { // Si no existe se inserta
                        resultado = db.pa_ClienteInsert(null, model.cedula, model.genero,
                                                        model.nombre, model.correo, model.provincia,
                                                        model.canton, model.distrito);
                    }
                    mensaje = "El registro ya existe!";

                }
                TempData["respuesta"] = new { existe = (existe > 0), mensaje };
                return RedirectToAction("index");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        [ActionName("eliminar")]
        [HttpGet]
        public ActionResult EliminarCliente(int id)
        {
            try
            {
                int resultado = db.pa_ClienteDelete(id);
                ViewBag.resultado = resultado > 0;
            }
            catch (Exception error)
            {
                throw error;
            }
            return RedirectToAction("index");
        }
    }
}
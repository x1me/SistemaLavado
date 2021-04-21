using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;
using SistemaLavado.Clases;

namespace SistemaLavado.Controllers
{
    public class ClientesController : Controller
    {

        sistemacontrolEntities db = new sistemacontrolEntities();
        public ActionResult Index()
        {

            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            return View("ListaClientes");
        }

        [HttpGet, ActionName("listar")]
        public ActionResult ListaClientes()
        {   
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            var cliente = db.pa_ClienteSelect(null).ToList();
            if (tipoUsuario != "a")
            {
                cliente = db.pa_ClienteSelect(idCliente).ToList();
            }
            var modelo = (from i in cliente
                          select new ClientePersonalizado()
                          {
                              id = i.id_cliente,
                              cedula = i.cedula,
                              nombre = i.nombre,
                              apellido1 = i.apellido1,
                              apellido2 = i.apellido2,
                              fecha_nacimiento = i.fecha_nacimiento.ToString(),
                              genero = i.genero,
                              correo = i.correo,
                              provincia = (from pt in db.Provincia where pt.id_Provincia == i.provincia select pt.nombre).FirstOrDefault(),
                              canton = (from ct in db.Canton where ct.id_Canton == i.canton select ct.nombre).FirstOrDefault(),
                              distrito = (from ds in db.Distrito where ds.id_Distrito == i.distrito select ds.nombre).FirstOrDefault(),
                          }
                          ).ToList();

            return Json(modelo, JsonRequestBehavior.AllowGet);

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

        [ActionName("agregar")]
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
                                                        model.genero, model.fecha_nacimiento,
                                                        model.nombre, model.apellido1, model.apellido2,
                                                        model.correo, model.provincia, model.canton,
                                                        model.distrito,model.estado);
                    mensaje = "Registro modificado";
                }
                else
                {
                    // Verificar si el cliente a insertar existe.
                    existe = db.Cliente.Where(e => e.cedula == model.cedula).Count();
                    if (existe == 0)
                    { // Si no existe se inserta
                        resultado = db.pa_ClienteInsert(model.cedula, model.genero,
                                                        model.nombre, model.correo,
                                                        model.provincia, model.canton,
                                                        model.distrito, model.fecha_nacimiento,
                                                        model.apellido1, model.apellido2, model.estado);
                        if (resultado > 0)
                        {
                            new Correo(model.correo).EnviaCorreo(model.nombre, model.apellido1, model.apellido2);
                            var idCliente = db.Cliente.Where(e => e.cedula == model.cedula).Select(e => e.id_cliente).FirstOrDefault();
                            db.pa_UsuarioInsert(idCliente, model.correo, model.cedula.ToString(), "u", DateTime.Now,model.estado);
                        }
                    }
                    mensaje = "El registro ya existe!";

                }
                ViewData["respuesta"] = new { existe = (existe > 0), mensaje };
                if (resultado > 0)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    return View(model.id_cliente);
                }
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
        [HttpGet]
        public ActionResult ObtenerInfo(int? provincia, int? canton)
        {
            try
            {
                List<pa_CantonSelect_Result> cantones = new List<pa_CantonSelect_Result>();
                object distritos = new object();
                if (provincia != null)
                {
                    cantones = db.pa_CantonSelect("", provincia).ToList();
                }
                else if (canton != null)
                {
                    distritos = (from dis in db.Distrito
                                 where dis.id_Canton == canton
                                 select new { 
                                     id_distrito = dis.id_Distrito,
                                     nombre = dis.nombre
                                 }
                                 ).ToList();
                }
                return Json(new { canton = cantones, distrito = distritos}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

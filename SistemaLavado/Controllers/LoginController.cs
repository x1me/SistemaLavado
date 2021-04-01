using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;

namespace SistemaLavado.Controllers
{
    public class LoginController : Controller
    {
        sistemacontrolEntities BD_Login = new sistemacontrolEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(usuarios usuario)
        {
            string clase = "alert-danger";
            try
            {
                int resultado = BD_Login.usuarios
                .Where(bd => bd.correo == usuario.correo &&
                            bd.contrasena == usuario.contrasena).Count();
                if (resultado > 0)
                {
                    // Busca usuario por su correo y retorna su id, tipo, ultima sesión.
                    var _usuario = BD_Login.usuarios
                                .Where(e => e.correo == usuario.correo)
                                .Select(e => new
                                {
                                    id = e.id_usuario,
                                    tipo = e.tipo,
                                    ultima = e.UltimaFecha
                                }).FirstOrDefault();
                    // Obtiene datos del cliente
                    var cliente = BD_Login.Cliente.Where((e) => e.id_cliente == _usuario.id).FirstOrDefault();
                    if (Session.Count > 0)
                    {
                        Session.RemoveAll();
                        Session["nombre"] = cliente.nombre;
                        Session["role"] = _usuario.tipo;
                        Session["ultima"] = _usuario.ultima;
                        Session["idCliente"] = cliente.id_cliente;
                    }
                    else
                    {
                        Session["nombre"] = cliente.nombre;
                        Session["role"] = _usuario.tipo;
                        Session["ultima"] = _usuario.ultima;
                        Session["idCliente"] = cliente.id_cliente;

                    }
                    return RedirectToAction("PaginaPrincipal", "Principal");
                }
                else
                {
                    ViewBag.mensaje = "Usuario o Contraseña Incorrecta!";
                    ViewBag.clase = clase;
                }

            }
            catch (Exception error)
            {
                throw error;
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult AgregarNuevoUsuario(int? id)
        {
            ViewBag.tipo = Session["role"] as string;
            Cliente cliente = new Cliente();
            ViewBag.provincias = BD_Login.pa_ProvinciaSelect(null, null).ToList();
            ViewBag.cantones = BD_Login.pa_CantonSelect(null, null).ToList();
            ViewBag.distritos = BD_Login.pa_DistritoSelect(null).ToList();
            if (id > 0)
            {
                cliente = BD_Login.Cliente.Where(e => e.id_cliente == id).FirstOrDefault();
            }
            return View();
        }
       
        

    }
    

}
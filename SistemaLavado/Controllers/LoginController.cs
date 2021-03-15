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
        sistemadecontrolEntities BD_Login = new sistemadecontrolEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var registro = BD_Login.pa_UsuariosSelect(null).ToList();
            return View(registro);

        }
        [HttpPost]
        public ActionResult Login(usuarios usuario)
        {
            int resultado = BD_Login.usuarios.Where(bd => bd.correo == usuario.correo && bd.contrasena == usuario.contrasena).Count();
            if (resultado >0)
            {
             ///   return Redirect;
            }
            return View();

        }

    }
}
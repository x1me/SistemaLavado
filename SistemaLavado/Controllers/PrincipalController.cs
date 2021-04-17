using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLavado.Models;
using SistemaLavado.Clases;

namespace SistemaLavado.Controllers
{
    public class PrincipalController : Controller
    {

        sistemacontrolEntities db = new sistemacontrolEntities();
        // GET: Principal
        public ActionResult PaginaPrincipal()
        {
            string tipoUsuario = Session["role"] as string;
            int? idCliente = Session["idCliente"] as Nullable<int>;
            ViewBag.tipo = tipoUsuario;
            var cliente = db.pa_ClienteSelect(idCliente).ToList();
            var usuario = (from i in cliente
                           select new BienvenidaInfo()
                           {
                               nombre = i.nombre,
                               apellidos = $"{i.apellido1} {i.apellido2}",
                               ultimaFecha = db.pa_UsuariosSelect(i.id_cliente).FirstOrDefault().UltimaFecha.ToString()
                           }
                           ).FirstOrDefault();
            return View(usuario);
        }


    }
}
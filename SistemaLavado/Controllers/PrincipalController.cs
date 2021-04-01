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
            var cliente = db.pa_ClienteSelect(null).ToList();
            if (tipoUsuario != "null")
            {
                cliente = db.pa_ClienteSelect(idCliente).ToList();
            }
            var modelo = (from i in cliente
                          select new ClientePersonalizado()
                          {
                              nombre = i.nombre,
                              apellido1 = i.apellido1,
                              apellido2 = i.apellido2,
                              fecha_nacimiento = (DateTime)i.fecha_nacimiento,
                          }
                          ).ToList();
            return View( modelo);
           
        }
    }
}
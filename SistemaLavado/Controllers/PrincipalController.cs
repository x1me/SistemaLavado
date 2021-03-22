using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLavado.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult PaginaPrincipal()
        {
            return View();
        }
    }
}
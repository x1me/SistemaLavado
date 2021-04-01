using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLavado.Models
{
    public class Mensaje
    {
        public string confirmacion { get; set; } = "Registro {} correctamente";
        public string error { get; set; }
        public bool estado { get; set; }
    }
}
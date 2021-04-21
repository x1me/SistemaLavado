using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLavado.Models
{
    public class ClientePersonalizado
    {
        public int id_cliente { get; set; }
        public int cedula { get; set; }
        public string genero { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string fecha_nacimiento { get; set; }        
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string estado { get; set; }

    }
}
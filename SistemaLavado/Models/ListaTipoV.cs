using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLavado.Models
{
    public class ListaTipoV
    {
        public Nullable<int> id_tipo { get; set; }
        public string tipo_nombre { get; set; }

    }
    public class ListaFabricante
    {
        public Nullable<int> id__fabricante { get; set; }
        public string fabricante_nombre { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaLavado.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        public int id_usuario { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> UltimaFecha { get; set; }
        public string estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}

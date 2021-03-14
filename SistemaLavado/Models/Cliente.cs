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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Servicios_Facturados_Encabezado = new HashSet<Servicios_Facturados_Encabezado>();
            this.Vehiculo = new HashSet<Vehiculo>();
        }
    
        public int cedula { get; set; }
        public string genero { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public Nullable<int> provincia { get; set; }
        public Nullable<int> canton { get; set; }
        public Nullable<int> distrito { get; set; }
    
        public virtual Canton Canton1 { get; set; }
        public virtual ICollection<Servicios_Facturados_Encabezado> Servicios_Facturados_Encabezado { get; set; }
        public virtual Distrito Distrito1 { get; set; }
        public virtual Provincia Provincia1 { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}

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
    
    public partial class Fabricante
    {
        public Fabricante()
        {
            this.MarcaVehiculo = new HashSet<MarcaVehiculo>();
        }
    
        public short codigo { get; set; }
        public string pais { get; set; }
    
        public virtual ICollection<MarcaVehiculo> MarcaVehiculo { get; set; }
    }
}

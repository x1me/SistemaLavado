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
    
    public partial class Servicios_Facturados_Detalle
    {
        public int id_SerFac_Deta { get; set; }
        public int id_encabezado { get; set; }
        public Nullable<short> tipo_servicio { get; set; }
        public Nullable<decimal> cantidad_servicio { get; set; }
        public Nullable<decimal> precio_servicio { get; set; }
    
        public virtual ServicioProducto ServicioProducto { get; set; }
        public virtual Servicios_Facturados_Encabezado Servicios_Facturados_Encabezado { get; set; }
    }
}

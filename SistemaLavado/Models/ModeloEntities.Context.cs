﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class sistemadecontrolEntities : DbContext
    {
        public sistemadecontrolEntities()
            : base("name=sistemadecontrolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Canton> Canton { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<MarcaVehiculo> MarcaVehiculo { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<ServicioProducto> ServicioProducto { get; set; }
        public DbSet<Servicios_Facturados_Detalle> Servicios_Facturados_Detalle { get; set; }
        public DbSet<Servicios_Facturados_Encabezado> Servicios_Facturados_Encabezado { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<View_2> View_2 { get; set; }
    
        public virtual int pa_CantonDelete(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CantonDelete", id_CantonParameter);
        }
    
        public virtual int pa_CantonInsert(Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CantonInsert", id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual ObjectResult<pa_CantonSelect_Result> pa_CantonSelect(string nombre, Nullable<int> id_Provincia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_CantonSelect_Result>("pa_CantonSelect", nombreParameter, id_ProvinciaParameter);
        }
    
        public virtual int pa_CantonUpdate(Nullable<int> id_Canton, Nullable<int> id_Provincia, string nombre, Nullable<int> id_CantonInec)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            var id_ProvinciaParameter = id_Provincia.HasValue ?
                new ObjectParameter("id_Provincia", id_Provincia) :
                new ObjectParameter("id_Provincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var id_CantonInecParameter = id_CantonInec.HasValue ?
                new ObjectParameter("id_CantonInec", id_CantonInec) :
                new ObjectParameter("id_CantonInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_CantonUpdate", id_CantonParameter, id_ProvinciaParameter, nombreParameter, id_CantonInecParameter);
        }
    
        public virtual int pa_ClienteDelete(Nullable<int> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ClienteDelete", cedulaParameter);
        }
    
        public virtual int pa_ClienteInsert(Nullable<int> cedula, string genero, string nombre, string correo, Nullable<int> provincia, Nullable<int> canton, Nullable<int> distrito)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("genero", genero) :
                new ObjectParameter("genero", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var provinciaParameter = provincia.HasValue ?
                new ObjectParameter("provincia", provincia) :
                new ObjectParameter("provincia", typeof(int));
    
            var cantonParameter = canton.HasValue ?
                new ObjectParameter("canton", canton) :
                new ObjectParameter("canton", typeof(int));
    
            var distritoParameter = distrito.HasValue ?
                new ObjectParameter("distrito", distrito) :
                new ObjectParameter("distrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ClienteInsert", cedulaParameter, generoParameter, nombreParameter, correoParameter, provinciaParameter, cantonParameter, distritoParameter);
        }
    
        public virtual ObjectResult<pa_ClienteSelect_Result> pa_ClienteSelect(Nullable<int> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_ClienteSelect_Result>("pa_ClienteSelect", cedulaParameter);
        }
    
        public virtual int pa_ClienteUpdate(Nullable<int> cedula, string genero, string nombre, string correo, Nullable<int> provincia, Nullable<int> canton, Nullable<int> distrito)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("genero", genero) :
                new ObjectParameter("genero", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var provinciaParameter = provincia.HasValue ?
                new ObjectParameter("provincia", provincia) :
                new ObjectParameter("provincia", typeof(int));
    
            var cantonParameter = canton.HasValue ?
                new ObjectParameter("canton", canton) :
                new ObjectParameter("canton", typeof(int));
    
            var distritoParameter = distrito.HasValue ?
                new ObjectParameter("distrito", distrito) :
                new ObjectParameter("distrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ClienteUpdate", cedulaParameter, generoParameter, nombreParameter, correoParameter, provinciaParameter, cantonParameter, distritoParameter);
        }
    
        public virtual int pa_DistritoDelete(Nullable<int> idDistrito, Nullable<int> idCanton)
        {
            var idDistritoParameter = idDistrito.HasValue ?
                new ObjectParameter("idDistrito", idDistrito) :
                new ObjectParameter("idDistrito", typeof(int));
    
            var idCantonParameter = idCanton.HasValue ?
                new ObjectParameter("idCanton", idCanton) :
                new ObjectParameter("idCanton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_DistritoDelete", idDistritoParameter, idCantonParameter);
        }
    
        public virtual int pa_DistritoInsert(Nullable<int> idCanton, string nombre, string usuarioCrea, Nullable<System.DateTime> fechaCrea, string usuarioModifica, Nullable<System.DateTime> fechaModifica, string vcEstado, Nullable<int> idDistritoInec)
        {
            var idCantonParameter = idCanton.HasValue ?
                new ObjectParameter("idCanton", idCanton) :
                new ObjectParameter("idCanton", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var usuarioCreaParameter = usuarioCrea != null ?
                new ObjectParameter("usuarioCrea", usuarioCrea) :
                new ObjectParameter("usuarioCrea", typeof(string));
    
            var fechaCreaParameter = fechaCrea.HasValue ?
                new ObjectParameter("fechaCrea", fechaCrea) :
                new ObjectParameter("fechaCrea", typeof(System.DateTime));
    
            var usuarioModificaParameter = usuarioModifica != null ?
                new ObjectParameter("usuarioModifica", usuarioModifica) :
                new ObjectParameter("usuarioModifica", typeof(string));
    
            var fechaModificaParameter = fechaModifica.HasValue ?
                new ObjectParameter("fechaModifica", fechaModifica) :
                new ObjectParameter("fechaModifica", typeof(System.DateTime));
    
            var vcEstadoParameter = vcEstado != null ?
                new ObjectParameter("vcEstado", vcEstado) :
                new ObjectParameter("vcEstado", typeof(string));
    
            var idDistritoInecParameter = idDistritoInec.HasValue ?
                new ObjectParameter("idDistritoInec", idDistritoInec) :
                new ObjectParameter("idDistritoInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_DistritoInsert", idCantonParameter, nombreParameter, usuarioCreaParameter, fechaCreaParameter, usuarioModificaParameter, fechaModificaParameter, vcEstadoParameter, idDistritoInecParameter);
        }
    
        public virtual ObjectResult<pa_DistritoSelect_Result> pa_DistritoSelect(Nullable<int> idDistrito)
        {
            var idDistritoParameter = idDistrito.HasValue ?
                new ObjectParameter("idDistrito", idDistrito) :
                new ObjectParameter("idDistrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_DistritoSelect_Result>("pa_DistritoSelect", idDistritoParameter);
        }
    
        public virtual int pa_DistritoUpdate(Nullable<int> idDistrito, Nullable<int> idCanton, string nombre, string usuarioCrea, Nullable<System.DateTime> fechaCrea, string usuarioModifica, Nullable<System.DateTime> fechaModifica, string vcEstado, Nullable<int> id_DistritoInec)
        {
            var idDistritoParameter = idDistrito.HasValue ?
                new ObjectParameter("idDistrito", idDistrito) :
                new ObjectParameter("idDistrito", typeof(int));
    
            var idCantonParameter = idCanton.HasValue ?
                new ObjectParameter("idCanton", idCanton) :
                new ObjectParameter("idCanton", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var usuarioCreaParameter = usuarioCrea != null ?
                new ObjectParameter("usuarioCrea", usuarioCrea) :
                new ObjectParameter("usuarioCrea", typeof(string));
    
            var fechaCreaParameter = fechaCrea.HasValue ?
                new ObjectParameter("fechaCrea", fechaCrea) :
                new ObjectParameter("fechaCrea", typeof(System.DateTime));
    
            var usuarioModificaParameter = usuarioModifica != null ?
                new ObjectParameter("usuarioModifica", usuarioModifica) :
                new ObjectParameter("usuarioModifica", typeof(string));
    
            var fechaModificaParameter = fechaModifica.HasValue ?
                new ObjectParameter("fechaModifica", fechaModifica) :
                new ObjectParameter("fechaModifica", typeof(System.DateTime));
    
            var vcEstadoParameter = vcEstado != null ?
                new ObjectParameter("vcEstado", vcEstado) :
                new ObjectParameter("vcEstado", typeof(string));
    
            var id_DistritoInecParameter = id_DistritoInec.HasValue ?
                new ObjectParameter("id_DistritoInec", id_DistritoInec) :
                new ObjectParameter("id_DistritoInec", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_DistritoUpdate", idDistritoParameter, idCantonParameter, nombreParameter, usuarioCreaParameter, fechaCreaParameter, usuarioModificaParameter, fechaModificaParameter, vcEstadoParameter, id_DistritoInecParameter);
        }
    
        public virtual int pa_fabricanteDelete(Nullable<int> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_fabricanteDelete", codigoParameter);
        }
    
        public virtual int pa_fabricanteInsert(Nullable<int> codigo, string pais)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var paisParameter = pais != null ?
                new ObjectParameter("pais", pais) :
                new ObjectParameter("pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_fabricanteInsert", codigoParameter, paisParameter);
        }
    
        public virtual ObjectResult<pa_fabricanteSelect_Result> pa_fabricanteSelect(Nullable<int> codigo, string pais)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var paisParameter = pais != null ?
                new ObjectParameter("pais", pais) :
                new ObjectParameter("pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_fabricanteSelect_Result>("pa_fabricanteSelect", codigoParameter, paisParameter);
        }
    
        public virtual int pa_FacturaDetalleInsert(Nullable<int> id_encabezado, Nullable<short> tipo_servicio, Nullable<decimal> cantidad_servicio, Nullable<decimal> precio_servicio)
        {
            var id_encabezadoParameter = id_encabezado.HasValue ?
                new ObjectParameter("id_encabezado", id_encabezado) :
                new ObjectParameter("id_encabezado", typeof(int));
    
            var tipo_servicioParameter = tipo_servicio.HasValue ?
                new ObjectParameter("tipo_servicio", tipo_servicio) :
                new ObjectParameter("tipo_servicio", typeof(short));
    
            var cantidad_servicioParameter = cantidad_servicio.HasValue ?
                new ObjectParameter("cantidad_servicio", cantidad_servicio) :
                new ObjectParameter("cantidad_servicio", typeof(decimal));
    
            var precio_servicioParameter = precio_servicio.HasValue ?
                new ObjectParameter("precio_servicio", precio_servicio) :
                new ObjectParameter("precio_servicio", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_FacturaDetalleInsert", id_encabezadoParameter, tipo_servicioParameter, cantidad_servicioParameter, precio_servicioParameter);
        }
    
        public virtual ObjectResult<pa_FacturaDetalleSelect_Result> pa_FacturaDetalleSelect(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_FacturaDetalleSelect_Result>("pa_FacturaDetalleSelect", idParameter);
        }
    
        public virtual int pa_FacturaDetalleUpdate(Nullable<int> id, Nullable<short> tipo_servicio, Nullable<decimal> cantidad_servicio, Nullable<decimal> precio_servicio)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var tipo_servicioParameter = tipo_servicio.HasValue ?
                new ObjectParameter("tipo_servicio", tipo_servicio) :
                new ObjectParameter("tipo_servicio", typeof(short));
    
            var cantidad_servicioParameter = cantidad_servicio.HasValue ?
                new ObjectParameter("cantidad_servicio", cantidad_servicio) :
                new ObjectParameter("cantidad_servicio", typeof(decimal));
    
            var precio_servicioParameter = precio_servicio.HasValue ?
                new ObjectParameter("precio_servicio", precio_servicio) :
                new ObjectParameter("precio_servicio", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_FacturaDetalleUpdate", idParameter, tipo_servicioParameter, cantidad_servicioParameter, precio_servicioParameter);
        }
    
        public virtual int pa_FacturaEncabezadoInsert(Nullable<int> id, Nullable<int> cedula, string placa, Nullable<System.DateTime> fecha, Nullable<decimal> monto_total, string estado)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var placaParameter = placa != null ?
                new ObjectParameter("placa", placa) :
                new ObjectParameter("placa", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var monto_totalParameter = monto_total.HasValue ?
                new ObjectParameter("monto_total", monto_total) :
                new ObjectParameter("monto_total", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_FacturaEncabezadoInsert", idParameter, cedulaParameter, placaParameter, fechaParameter, monto_totalParameter, estadoParameter);
        }
    
        public virtual ObjectResult<pa_FacturaEncabezadoSelect_Result> pa_FacturaEncabezadoSelect(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_FacturaEncabezadoSelect_Result>("pa_FacturaEncabezadoSelect", idParameter);
        }
    
        public virtual int pa_FacturaEncabezadoUpdate(Nullable<int> id, Nullable<int> cedula, string placa, Nullable<System.DateTime> fecha, Nullable<decimal> monto_total, string estado)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var placaParameter = placa != null ?
                new ObjectParameter("placa", placa) :
                new ObjectParameter("placa", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var monto_totalParameter = monto_total.HasValue ?
                new ObjectParameter("monto_total", monto_total) :
                new ObjectParameter("monto_total", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_FacturaEncabezadoUpdate", idParameter, cedulaParameter, placaParameter, fechaParameter, monto_totalParameter, estadoParameter);
        }
    
        public virtual int pa_ProvinciaDelete(Nullable<int> idProvincia)
        {
            var idProvinciaParameter = idProvincia.HasValue ?
                new ObjectParameter("idProvincia", idProvincia) :
                new ObjectParameter("idProvincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ProvinciaDelete", idProvinciaParameter);
        }
    
        public virtual int pa_ProvinciaInsert(string nombre, string usuarioCrea, Nullable<System.DateTime> fechaCrea, string usuarioModifica, Nullable<System.DateTime> fechaModifica, string vcEstado)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var usuarioCreaParameter = usuarioCrea != null ?
                new ObjectParameter("usuarioCrea", usuarioCrea) :
                new ObjectParameter("usuarioCrea", typeof(string));
    
            var fechaCreaParameter = fechaCrea.HasValue ?
                new ObjectParameter("fechaCrea", fechaCrea) :
                new ObjectParameter("fechaCrea", typeof(System.DateTime));
    
            var usuarioModificaParameter = usuarioModifica != null ?
                new ObjectParameter("usuarioModifica", usuarioModifica) :
                new ObjectParameter("usuarioModifica", typeof(string));
    
            var fechaModificaParameter = fechaModifica.HasValue ?
                new ObjectParameter("fechaModifica", fechaModifica) :
                new ObjectParameter("fechaModifica", typeof(System.DateTime));
    
            var vcEstadoParameter = vcEstado != null ?
                new ObjectParameter("vcEstado", vcEstado) :
                new ObjectParameter("vcEstado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ProvinciaInsert", nombreParameter, usuarioCreaParameter, fechaCreaParameter, usuarioModificaParameter, fechaModificaParameter, vcEstadoParameter);
        }
    
        public virtual ObjectResult<pa_ProvinciaSelect_Result> pa_ProvinciaSelect(string nombre, Nullable<int> idProvincia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var idProvinciaParameter = idProvincia.HasValue ?
                new ObjectParameter("idProvincia", idProvincia) :
                new ObjectParameter("idProvincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_ProvinciaSelect_Result>("pa_ProvinciaSelect", nombreParameter, idProvinciaParameter);
        }
    
        public virtual int pa_ProvinciaUpdate(Nullable<int> idProvincia, string nombre, string vcEstado)
        {
            var idProvinciaParameter = idProvincia.HasValue ?
                new ObjectParameter("idProvincia", idProvincia) :
                new ObjectParameter("idProvincia", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var vcEstadoParameter = vcEstado != null ?
                new ObjectParameter("vcEstado", vcEstado) :
                new ObjectParameter("vcEstado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ProvinciaUpdate", idProvinciaParameter, nombreParameter, vcEstadoParameter);
        }
    
        public virtual int pa_ServicioProductoDelete(Nullable<int> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ServicioProductoDelete", codigoParameter);
        }
    
        public virtual int pa_ServicioProductoInsert(Nullable<int> codigo, string descripcion, Nullable<float> precio, Nullable<short> tipo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(float));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ServicioProductoInsert", codigoParameter, descripcionParameter, precioParameter, tipoParameter);
        }
    
        public virtual ObjectResult<pa_ServicioProductoSelect_Result> pa_ServicioProductoSelect(Nullable<int> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_ServicioProductoSelect_Result>("pa_ServicioProductoSelect", codigoParameter);
        }
    
        public virtual int pa_ServicioProductoUpdate(Nullable<int> codigo, string descripcion, Nullable<float> precio, Nullable<short> tipo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("descripcion", descripcion) :
                new ObjectParameter("descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(float));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_ServicioProductoUpdate", codigoParameter, descripcionParameter, precioParameter, tipoParameter);
        }
    
        public virtual ObjectResult<pa_UsuariosSelect_Result> pa_UsuariosSelect(Nullable<int> idUsuarios)
        {
            var idUsuariosParameter = idUsuarios.HasValue ?
                new ObjectParameter("idUsuarios", idUsuarios) :
                new ObjectParameter("idUsuarios", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_UsuariosSelect_Result>("pa_UsuariosSelect", idUsuariosParameter);
        }
    
        public virtual ObjectResult<RetornaCantonesID_Result> RetornaCantonesID(Nullable<int> id_Canton)
        {
            var id_CantonParameter = id_Canton.HasValue ?
                new ObjectParameter("id_Canton", id_Canton) :
                new ObjectParameter("id_Canton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetornaCantonesID_Result>("RetornaCantonesID", id_CantonParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<pa_RetornaFabricante_Result> pa_RetornaFabricante()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_RetornaFabricante_Result>("pa_RetornaFabricante");
        }
    
        public virtual ObjectResult<pa_RetornaFabricante_ID_Result> pa_RetornaFabricante_ID(Nullable<int> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pa_RetornaFabricante_ID_Result>("pa_RetornaFabricante_ID", codigoParameter);
        }
    
        public virtual int pa_FabricanteModifica(Nullable<int> codigo, string pais)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            var paisParameter = pais != null ?
                new ObjectParameter("pais", pais) :
                new ObjectParameter("pais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pa_FabricanteModifica", codigoParameter, paisParameter);
        }
    }
}

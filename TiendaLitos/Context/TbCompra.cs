//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaLitos.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TbCompra()
        {
            this.TbDetalleCompra = new HashSet<TbDetalleCompra>();
        }
    
        public int IdCompra { get; set; }
        public Nullable<System.DateTime> FechaCompra { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Iva { get; set; }
        public Nullable<bool> Anular { get; set; }
        public Nullable<double> Total { get; set; }
        public string NoFactura { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdTipoMoneda { get; set; }
    
        public virtual TbProveedor TbProveedor { get; set; }
        public virtual TbUsuario TbUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TbDetalleCompra> TbDetalleCompra { get; set; }
    }
}

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
    
    public partial class TbDetalleVenta
    {
        public Nullable<int> IdVenta { get; set; }
        public Nullable<int> IdArticulo { get; set; }
        public string DescripciónArticulo { get; set; }
        public string UdMedidaVenta { get; set; }
        public Nullable<double> PrecioPorUnidad { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<double> Descuento { get; set; }
        public Nullable<decimal> Pago { get; set; }
        public Nullable<decimal> Cambio { get; set; }
        public int IdDetalleVenta { get; set; }
    
        public virtual TbVenta TbVenta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
   public class ReporteProductosMasVendidos
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}

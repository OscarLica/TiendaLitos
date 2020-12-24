using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class ReportVentas
    {
        public int IdVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public string Fecha => FechaVenta.Value.ToShortDateString();
        public double? Iva { get; set; }
        public double? SubTotal { get; set; }
        public double? SubTotalLocal { get; set; }
        public double? Total { get; set; }
        public double? TotalLocal { get; set; }
        public string Cliente { get; set; }

        public string Articulo { get; set; }
        public double? Cantidad { get; set; }
        public string Color { get; set; }
        public string Medida { get; set; }
        public string Marca { get; set; }
        public string Talla { get; set; }
        public decimal? Precio { get; set; }
        public double? Descuento { get; set; }
        public decimal? SubTotalDetalle { get; set; }
        public string Moneda { get; set; }
        public double TasaCambio { get; set; }
    }
}

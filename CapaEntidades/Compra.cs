using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string Fecha { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Iva { get; set; }
        public Nullable<bool> Anular { get; set; }
        public Nullable<double> Total { get; set; }
        public string NoFactura { get; set; }
        public string Proveedor { get; set; }
        public string Moneda { get; set; }
        public double TasaCambio { get; set; }

        public double? SubTotalLocal { get; set; }
        public double? TotalLocal { get; set; }
        public IQueryable<DetCompra> detalle { get; set; }
    }

    public class DetCompra {
        public string Articulo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public string Medida { get; set; }
        public string Talla { get; set; }
        public double? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? PrecioVenta { get; set; }
        public double? Descuento { get; set; }
        public double? SubTotalArticulo { get; set; }
        public double? SubTotalArticuloLocal { get; set; }
        public string SubCategoria { get; set; }
    }
}

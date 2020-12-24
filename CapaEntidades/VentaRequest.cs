using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class VentaRequest
    {
        public Ventas Venta { get; set; }
        public List<DetalleVenta> DetalleVenta { get; set; }
    }

    public class Ventas
    {
        public int Iva { get; set; }
        public double SubTotalVenta { get; set; }
        public double TotalVenta { get; set; }
        public string Cliente { get; set; }
        public int IdTipoMoneda { get; set; }
    }

    public class DetalleVenta
    {

        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public string UdMedidaVenta { get; set; }
        public double? PrecioPorUnida { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int Descuento { get; set; }
        public decimal? SubTotalArticulo { get; set; }
        public decimal? Pago { get; set; }
        public decimal? Cambio { get; set; }
    }
}

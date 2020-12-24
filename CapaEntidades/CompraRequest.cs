using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class CompraRequest
    {
        public Compras Compra { get; set; } = new Compras();

        public List<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();
    }

    public class Compras {
        public int Iva { get; set; }
        public double SubTotalCompra { get; set; }
        public double TotalCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdTipoMoneda { get; set; }
    }

    public class DetalleCompra
    {
        public int IdArticulo { get; set; }
        public int IdBodega { get; set; }
        public int IdMedida { get; set; }
        public int IdMarca { get; set; }
        public int IdColor { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double PrecioVenta { get; set; }
        public double Descuento { get; set; }
        public double SubTotalArticulo { get; set; }
    }
}

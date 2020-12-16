using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class ArtBodega
    {
        public int IdBodega { get; set; }
        public string Bodega { get; set; }

        public double TotalPCompra { get; set; }
        public double TotalPVenta { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalDescuentoMaximo { get; set; }
        public int TotalCantidad { get; set; }

        public List<ArticuloBodega> ArticuloBodega { get; set; }
    }

    public class ArticuloBodega
    {
        public string Articulo { get; set; }
        public double PCompra { get; set; }
        public double PVenta { get; set; }
        public double Descuento { get; set; }
        public double DescuentoMaximo { get; set; }
        public string Cantidad { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class ArticuloBodegaResult
    {
        public string Bodega { get; set; }
        public int IdArticuloBodega { get; set; }
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public string Medida { get; set; }
        public string Talla { get; set; }
        public string Existencia { get; set; }
        public bool Estado { get; set; }
        public double? PrecioPorUnida { get; set; }
    }
}

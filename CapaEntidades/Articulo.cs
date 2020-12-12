using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripción { get; set; }
        public string  NombreSubCategoria{ get; set; }
        public int IdSubCategoria { get; set; }
        public bool Estado { get; set; }
    }
}

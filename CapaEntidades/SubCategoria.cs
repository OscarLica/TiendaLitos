using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class SubCategoria
    {
        public int IdSubCategoria { get; set; }
        public int IdCategoria { get; set; }
        public string Descripción { get; set; }
        public bool Estado { get; set; }

    }
}

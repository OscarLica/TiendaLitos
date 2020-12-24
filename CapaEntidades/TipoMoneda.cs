using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class TipoMoneda
    {
        public int IdTipoMoneda { get; set; }
        public string TMoneda { get; set; }
        public double TasaCambio { get; set; }
        public bool Activo { get; set; }
    }
}

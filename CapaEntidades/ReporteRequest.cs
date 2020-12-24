using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class ReporteRequest
    {
        public int TipoReporte { get; set; }
        public DateTime? FInicio { get; set; }
        public DateTime? FFinal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class Medida
    {
        public int IdMedida { get; set; }
        public string NombreMedida { get; set; }
        public double? PrecioMedida { get; set; }
        public double? UdidadesEquivalente { get; set; }
    }
}

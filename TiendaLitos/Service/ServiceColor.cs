using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceColor
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceColor(TiendaLitosEntities Context)
        {
            _Context = Context;
        }
        public List<Color> GetAllColor()
        {
            var colores = _Context.TbColor.Select(x => new Color
            {
                Estado = x.Estado,
                IdColor = x.IdColor,
                NombreColor = x.NombreColor,
            }).ToList();
            return colores;
        }
    }
}
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceTalla
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceTalla(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Talla> GetAllTallas()
        {
            return _Context.TbTalla.Select(x => new Talla
            {
                Estado = x.Estado,
                IdTalla = x.IdTalla,
                NombreTalla = x.NombreTalla,
            }).ToList();
        }
    }
}
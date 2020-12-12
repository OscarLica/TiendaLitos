using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceBodega
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceBodega(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Bodega> GetAllBodegas() {
            return (from b in _Context.TbBodega
                    select new Bodega {
                    IdBodega = b.IdBodega,
                    Descripción = b.Descripción,
                    Nombre = b.Bodega
                    }).ToList();
        }
    }
}
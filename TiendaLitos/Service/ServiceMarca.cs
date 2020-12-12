using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceMarca
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceMarca(TiendaLitosEntities Context)
        {
            _Context = Context;
        }
        public List<Marca> GetAllMarcas()
        {
            return _Context.TbMarca.Select(x => new Marca
            {
                Estado = x.Estado ?? default,
                IdMarca = x.IdMarca,
                NombreMarca = x.NombreMarca
            }).ToList();
        }
    }
}
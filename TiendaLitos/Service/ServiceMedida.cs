using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceMedida
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceMedida(TiendaLitosEntities Context)
        {
            _Context = Context;
        }
        public List<Medida> GetAllMedidaes()
        {
            return _Context.TbMedida.Select(x => new Medida
            {
                IdMedida = x.IdMedida,
                NombreMedida = x.NombreMedida,
                PrecioMedida = x.PrecioMedida,
                UdidadesEquivalente = x.UdidadesEquivalente,
            }).ToList();
        }

    }
}
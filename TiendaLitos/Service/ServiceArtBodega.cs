using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceArtBodega
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceArtBodega(TiendaLitosEntities Context)
        {
            _Context = Context;

        }

        public List<ArtBodega> GetArticulosBodega() {

            var art = (from ab in _Context.TbArticuloBodega
                       join b in _Context.TbBodega on ab.IdBodega equals b.IdBodega
                       group b by new { b.IdBodega, b.Bodega }
                       into grupoBodega
                       select new ArtBodega { 
                       IdBodega = grupoBodega.Key.IdBodega,
                       Bodega = grupoBodega.Key.Bodega,
                       ArticuloBodega = (from a in _Context.TbArticuloBodega
                                         join arti in _Context.TbArticulo on a.IdArticulo equals arti.IdArticulo
                                         where a.IdBodega == grupoBodega.Key.IdBodega 
                                         select new ArticuloBodega { 
                                             Articulo = arti.NombreArticulo,
                                             Descuento = a.Descuento ?? default,
                                             DescuentoMaximo = a.DescuentoMaximo ?? default,
                                             PCompra = a.PrecioCompra ?? default,
                                             PVenta = a.PrecioVenta ?? default
                                         }).ToList()
                       }).ToList();
            foreach (var item in art)
            {
                item.TotalPVenta = item.ArticuloBodega.Sum(x => x.PVenta);
                item.TotalPCompra = item.ArticuloBodega.Sum(x => x.PCompra);
                item.TotalDescuento = item.ArticuloBodega.Sum(x => x.Descuento);
                item.TotalDescuentoMaximo = item.ArticuloBodega.Sum(x => x.DescuentoMaximo);
            }
            return art;
        }
    }
}
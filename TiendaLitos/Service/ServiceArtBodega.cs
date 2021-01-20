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

        public List<ArticuloBodegaResult> GetAllArticulosBodega()
        {

            var result = (from ab in _Context.TbArticuloBodega
                          join a in _Context.TbArticulo on ab.IdArticulo equals a.IdArticulo
                          join subcat in _Context.TbSubCategoria on a.IdSubCategoria equals subcat.IdSubCategoria
                          join c in _Context.TbColor on ab.IdColor equals c.IdColor
                          join t in _Context.TbTalla on ab.IdTalla equals t.IdTalla
                          join m in _Context.TbMedida on ab.IdMedida equals m.IdMedida
                          join ma in _Context.TbMarca on ab.IdMedida equals ma.IdMarca
                          select new ArticuloBodegaResult
                          {
                              Articulo = a.NombreArticulo,
                              Color = c.NombreColor,
                              Existencia = ab.Existencia,
                              IdArticulo = ab.IdArticulo ?? default,
                              IdArticuloBodega = ab.IdArticuloBodega,
                              Marca = ma.NombreMarca,
                              Medida = m.NombreMedida,
                              Talla = t.NombreTalla,
                              Estado = a.Estado ?? default,
                              PrecioPorUnida = ab.PrecioVenta,
                              SubCategoria = subcat.Descripción
                          }).ToList();

            return result;
        }

        public List<ArticuloBodegaResult> GetAllArticulosBodegaReporte()
        {

            var result = (from ab in _Context.TbArticuloBodega
                          join b in _Context.TbBodega on ab.IdBodega equals b.IdBodega
                          join a in _Context.TbArticulo on ab.IdArticulo equals a.IdArticulo
                          join c in _Context.TbColor on ab.IdColor equals c.IdColor
                          join t in _Context.TbTalla on ab.IdTalla equals t.IdTalla
                          join m in _Context.TbMedida on ab.IdMedida equals m.IdMedida
                          join ma in _Context.TbMarca on ab.IdMedida equals ma.IdMarca
                          select new ArticuloBodegaResult
                          {
                              Bodega = b.Bodega,
                              Articulo = a.NombreArticulo,
                              Color = c.NombreColor,
                              Existencia = ab.Existencia,
                              IdArticulo = ab.IdArticulo ?? default,
                              IdArticuloBodega = ab.IdArticuloBodega,
                              Marca = ma.NombreMarca,
                              Medida = m.NombreMedida,
                              Talla = t.NombreTalla,
                              Estado = a.Estado ?? default,
                              PrecioPorUnida = ab.PrecioVenta
                          }).ToList();

            return result;
        }
        public List<ArtBodega> GetArticulosBodega()
        {

            var art = (from ab in _Context.TbArticuloBodega
                       join b in _Context.TbBodega on ab.IdBodega equals b.IdBodega
                       group b by new { b.IdBodega, b.Bodega }
                       into grupoBodega
                       select new ArtBodega
                       {
                           IdBodega = grupoBodega.Key.IdBodega,
                           Bodega = grupoBodega.Key.Bodega,
                           ArticuloBodega = (from a in _Context.TbArticuloBodega
                                             join arti in _Context.TbArticulo on a.IdArticulo equals arti.IdArticulo
                                             where a.IdBodega == grupoBodega.Key.IdBodega
                                             select new ArticuloBodega
                                             {
                                                 Articulo = arti.NombreArticulo,
                                                 Descuento = a.Descuento ?? default,
                                                 DescuentoMaximo = a.DescuentoMaximo ?? default,
                                                 PCompra = a.PrecioCompra ?? default,
                                                 PVenta = a.PrecioVenta ?? default,
                                                 Cantidad = a.Existencia
                                             }).ToList()
                       }).ToList();
            foreach (var item in art)
            {
                item.TotalPVenta = item.ArticuloBodega.Sum(x => x.PVenta);
                item.TotalPCompra = item.ArticuloBodega.Sum(x => x.PCompra);
                item.TotalDescuento = item.ArticuloBodega.Sum(x => x.Descuento);
                item.TotalDescuentoMaximo = item.ArticuloBodega.Sum(x => x.DescuentoMaximo);
                item.TotalCantidad = item.ArticuloBodega.Sum(x => Convert.ToInt32(x.Cantidad));
            }
            return art;
        }
    }
}
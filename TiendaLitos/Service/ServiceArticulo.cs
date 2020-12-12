using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceArticulo
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceArticulo(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Articulo> GetAllArticulos()
        {

            return (from a in _Context.TbArticulo
                    join s in _Context.TbSubCategoria on a.IdSubCategoria equals s.IdSubCategoria
                    select new Articulo
                    {
                        Descripción = a.Descripción,
                        Estado = a.Estado ?? default,
                        IdArticulo = a.IdArticulo,
                        NombreSubCategoria = s.Descripción,
                        NombreArticulo = a.NombreArticulo,

                    }).ToList();
        }

        public Articulo GetArticuloById(int IdArticulo)
        {

            return _Context.TbArticulo.Where(y => y.IdArticulo == IdArticulo).Select(x => new Articulo
            {
                Descripción = x.Descripción,
                Estado = x.Estado ?? default,
                IdArticulo = x.IdArticulo,
                IdSubCategoria = x.IdSubCategoria ?? default,
                NombreArticulo = x.NombreArticulo,

            }).FirstOrDefault();
        }

        public Result CreateArticulo(TbArticulo articulo)
        {
            var existe = _Context.TbArticulo.FirstOrDefault(x => x.NombreArticulo == articulo.NombreArticulo);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe un articulo con el nombre {articulo.NombreArticulo}"};

            _Context.TbArticulo.Add(articulo);
            _Context.SaveChanges();

            return new Result { SuccesFull = true, Message = "Articulo guardado exitosamente."};
        }

        public Result UpdateArticulo(TbArticulo articulo)
        {
            var existe = _Context.TbArticulo.FirstOrDefault(x => x.NombreArticulo == articulo.NombreArticulo && x.IdArticulo != articulo.IdArticulo);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe un articulo con el nombre {articulo.NombreArticulo}" };

            var art = _Context.TbArticulo.Find(articulo.IdArticulo);
            art.IdSubCategoria = articulo.IdSubCategoria;
            art.NombreArticulo = articulo.NombreArticulo;
            art.Descripción = articulo.Descripción;
            art.Estado = articulo.Estado;
            _Context.SaveChanges();

            return new Result { SuccesFull = true, Message = "Articulo modificado exitosamente." };
        }
    }
}
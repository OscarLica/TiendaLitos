using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceCategoria
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceCategoria(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Categorias> GetAllCategorias()
        {
            return _Context.TbCategoria.Select(x => new Categorias
            {
                Estado = x.Estado ?? false,
                IdCategoria = x.IdCategoria,
                NombreCategoria = x.NombreCategoria

            }).ToList();
        }

        public Categorias ObtenerCategoria(int IdCategoria)
        {
            return _Context.TbCategoria.Select(x => new Categorias
            {
                Estado = x.Estado ?? false,
                IdCategoria = x.IdCategoria,
                NombreCategoria = x.NombreCategoria
            }).FirstOrDefault(y => y.IdCategoria == IdCategoria);
        }

        public Result CrearCategoria(TbCategoria categoria)
        {

            var existe = _Context.TbCategoria.FirstOrDefault(x => x.NombreCategoria == categoria.NombreCategoria);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe una categoria con el nombre {categoria.NombreCategoria}." };

            _Context.TbCategoria.Add(categoria);
            _Context.SaveChanges();
            return new Result { SuccesFull = true, Message = "Categoria agregada exitosamente." };

        }

        public Result UpdateCategoria(TbCategoria categoria)
        {
            var existe = _Context.TbCategoria.FirstOrDefault(x => x.NombreCategoria == categoria.NombreCategoria && x.IdCategoria != categoria.IdCategoria);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe una categoria con el nombre {categoria.NombreCategoria}." };

            var cate = _Context.TbCategoria.Find(categoria.IdCategoria);

            cate.NombreCategoria = categoria.NombreCategoria;
            cate.Estado = categoria.Estado;
            _Context.SaveChanges();
            return new Result { SuccesFull = true, Message = $"Cateoria modificada exitosamente." };
        }
    }
}
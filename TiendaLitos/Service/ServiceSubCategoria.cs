using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceSubCategoria
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceSubCategoria(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<SubCategoriaResponse> GetAllSubCategorias() {
            try
            {
                var result = (from sub in _Context.TbSubCategoria
                              join cate in _Context.TbCategoria on sub.IdCategoria equals cate.IdCategoria
                              select new SubCategoriaResponse
                              {
                                  IdSubCategoria = sub.IdSubCategoria,
                                  Descripcion = sub.Descripción,
                                  Estado = sub.Estado ?? false,
                                  NombreCategoria = cate.NombreCategoria
                              }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return new List<SubCategoriaResponse>();
            }
        }

        public SubCategoria GetSubCategoriaById(int IdSubCategoria) {
            return (from sub in _Context.TbSubCategoria
                    where sub.IdSubCategoria == IdSubCategoria
                    select new SubCategoria { 
                        IdCategoria = sub.IdCategoria ?? default,
                        IdSubCategoria = sub.IdSubCategoria,
                        Descripción = sub.Descripción,
                        Estado = sub.Estado ?? false
                    }).FirstOrDefault();
        }

        public TbSubCategoria CreateSubCategoria(TbSubCategoria subCategoria) {

            _Context.TbSubCategoria.Add(subCategoria);
            _Context.SaveChanges();
            return subCategoria;
        }
        public TbSubCategoria UpdateSubCategoria(TbSubCategoria subCategoria)
        {
            var sub = _Context.TbSubCategoria.Find(subCategoria.IdSubCategoria);

            sub.Descripción = subCategoria.Descripción;
            sub.IdSubCategoria = subCategoria.IdSubCategoria;
            sub.Estado = subCategoria.Estado;
            _Context.SaveChanges();
            return sub;
        }
    }
}
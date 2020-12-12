using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;
using TiendaLitos.Service;
using Entidad = CapaEntidades;

namespace TiendaLitos.Pages
{
    public partial class SubCategoria : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceSubCategoria ServiceSubCategoria { get; set; }
        public SubCategoria()
        {
            _Context = new TiendaLitosEntities();
            ServiceSubCategoria = new ServiceSubCategoria(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        public static List<SubCategoriaResponse> GetAllSubCategorias()
        {
            var result = ServiceSubCategoria.GetAllSubCategorias();
            return result;
        }

        [WebMethod]
        public static Entidad.SubCategoria ObtenerSubCategoria(int IdSubCategoria)
        {
            var result = ServiceSubCategoria.GetSubCategoriaById(IdSubCategoria);
            return result;
        }

        [WebMethod]
        public static Result CreateSubCategoria(TbSubCategoria subCategoria)
        {
            var result = ServiceSubCategoria.CreateSubCategoria(subCategoria);
            return new Result { SuccesFull = true, Message = "Sub Categoria creada exitosamente." };
        }

        [WebMethod]
        public static Result UpdateSubCategoria(TbSubCategoria subCategoria)
        {
            var result = ServiceSubCategoria.UpdateSubCategoria(subCategoria);
            return new Result { SuccesFull = true, Message = "Sub Categoria actualizada exitosamente." };
        }
    }
}
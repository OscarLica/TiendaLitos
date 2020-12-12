using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;
using TiendaLitos.Service;

namespace TiendaLitos.Pages
{
    public partial class Categoria : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceCategoria ServiceCategoria { get; set; }
        public Categoria()
        {
            _Context = new TiendaLitosEntities();
            ServiceCategoria = new ServiceCategoria(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Categorias> GetCategorias()
        {
            var result = ServiceCategoria.GetAllCategorias();
            return result;
        }

        [WebMethod]
        public static Categorias ObtenerCategoria(int IdCategoria) {
            var result = ServiceCategoria.ObtenerCategoria(IdCategoria);
            return result;
        }

        [WebMethod]
        public static Result CreateCategoria(TbCategoria categoria)
        {
            var result = ServiceCategoria.CrearCategoria(categoria);
            return result;
        }

        [WebMethod]
        public static Result UpdateCategoria(TbCategoria categoria)
        {
            var result = ServiceCategoria.UpdateCategoria(categoria);
            return result;
        }
    }
}
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
using Entidades = CapaEntidades;

namespace TiendaLitos.Pages
{
    public partial class Articulo : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceArticulo ServiceArticulo { get; set; }
        public Articulo()
        {
            _Context = new TiendaLitosEntities();
            ServiceArticulo = new ServiceArticulo(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Entidades.Articulo> GetAllArticulos()
             => ServiceArticulo.GetAllArticulos();

        [WebMethod]
        public static Entidades.Articulo GetArticuloById(int IdArticulo)
            => ServiceArticulo.GetArticuloById(IdArticulo);

        [WebMethod]
        public static Result CreateArticulo (TbArticulo articulo)
        {
            
            return ServiceArticulo.CreateArticulo(articulo);
        }

        [WebMethod]
        public static Result UpdateArticulo(TbArticulo articulo)
        {
            return ServiceArticulo.UpdateArticulo(articulo);
        }
    }
}
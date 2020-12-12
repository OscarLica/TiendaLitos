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

namespace TiendaLitos.Pages
{
    public partial class Compras : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context;
        public static ServiceCompras ServiceCompras;
        public Compras()
        {
            _Context = new TiendaLitosEntities();
            ServiceCompras = new ServiceCompras(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.Proveedor> GetAllProveedores() {
            return ServiceCompras.GetAllProveedores();
        }

        [WebMethod]
        public static Result Comprar(CompraRequest compraRequest)
        {
             return ServiceCompras.Comprar(compraRequest);
        }
    }
}
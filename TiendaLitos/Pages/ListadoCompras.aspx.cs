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
    public partial class ListadoCompras : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceCompras ServiceCompras { get; set; }
        public ListadoCompras()
        {
            _Context = new TiendaLitosEntities();
            ServiceCompras = new ServiceCompras(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.Compra> ConsultarCompras() {
            return ServiceCompras.ConsultarComprar();
        }

    }
}
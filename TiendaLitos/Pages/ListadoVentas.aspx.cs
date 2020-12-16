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
    public partial class ListadoVentas : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceVenta ServiceVenta { get; set; }
        public ListadoVentas()
        {
            _Context = new TiendaLitosEntities();
            ServiceVenta = new ServiceVenta(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.Venta> ConsultarVentas()
        {
            return ServiceVenta.ConsultarVentas();
        }
    }
}
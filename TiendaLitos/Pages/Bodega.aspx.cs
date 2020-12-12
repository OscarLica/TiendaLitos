using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;
using TiendaLitos.Service;
using Entidades = CapaEntidades;
namespace TiendaLitos.Pages
{
    public partial class Bodega : System.Web.UI.Page
    {
        public static ServiceBodega ServiceBodega{ get; set; }
        public TiendaLitosEntities _Context { get; set; }
        public Bodega()
        {
            _Context = new TiendaLitosEntities();
            ServiceBodega = new ServiceBodega(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Entidades.Bodega> GetAllBodega() {
            return ServiceBodega.GetAllBodegas();
        }
    }
}
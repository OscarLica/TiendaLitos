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
    public partial class Medida : System.Web.UI.Page
    {
        public static ServiceMedida ServiceMedida { get; set; }
        public TiendaLitosEntities _Context { get; set; }

        public Medida()
        {
            _Context = new TiendaLitosEntities();
            ServiceMedida = new ServiceMedida(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.Medida> GetAllMedidas()
        {
            return ServiceMedida.GetAllMedidaes();
        }
    }
}
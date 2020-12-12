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
    public partial class Marca : System.Web.UI.Page
    {
        public static ServiceMarca ServiceMarca { get; set; }
        public TiendaLitosEntities _Context { get; set; }
        public Marca()
        {
            _Context = new TiendaLitosEntities();
            ServiceMarca = new ServiceMarca(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.Marca> GetAllMarcas() {
            return ServiceMarca.GetAllMarcas();
        }
    }
}
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
    public partial class Talla : System.Web.UI.Page
    {
        public static ServiceTalla ServiceTalla { get; set; }
        public TiendaLitosEntities _Context { get; set; }

        public Talla()
        {
            _Context = new TiendaLitosEntities();
            ServiceTalla = new ServiceTalla(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CapaEntidades.Talla> GetAllTallas()
        {
            return ServiceTalla.GetAllTallas();
        }
    }
}
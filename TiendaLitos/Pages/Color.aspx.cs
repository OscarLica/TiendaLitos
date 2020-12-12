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
    public partial class Color : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceColor ServiceColor { get; set; }
        public Color()
        {
            _Context = new TiendaLitosEntities();
            ServiceColor = new ServiceColor(_Context);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<CapaEntidades.Color> GetAllColor()
        {
            return ServiceColor.GetAllColor();
        }
    }
}
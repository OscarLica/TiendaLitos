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
    public partial class ArticuloBodega : System.Web.UI.Page
    {
        public static ServiceArtBodega ServiceArtBodega { get; set; }
        public TiendaLitosEntities _Context { get; set; }
        public ArticuloBodega()
        {
            _Context = new TiendaLitosEntities();
            ServiceArtBodega = new ServiceArtBodega(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.ArticuloBodegaResult> GetAllArticulosBodega()
        {
            return ServiceArtBodega.GetAllArticulosBodega();
        }

        [WebMethod]
        public static List<ArtBodega> GetArticulosBodega()
        {
            return ServiceArtBodega.GetArticulosBodega();
        }
    }
}
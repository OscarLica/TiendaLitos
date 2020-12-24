using CapaEntidades;
using Microsoft.Reporting.WebForms;
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
        public static string ReporteArticuloBodega(CapaEntidades.ReporteRequest reporteRequest)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            var datos = ServiceArtBodega.GetAllArticulosBodegaReporte();
            var path = "./Reports/ReportProductosBodega/ReportProductosBodega.rdlc";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            ReportDataSource ds = new ReportDataSource("DataSet1", datos);
            localReport.DataSources.Add(ds);

            byte[] bytes = localReport.Render("PDF", null, out mimeType, out filenameExtension, out encoding, out streamids, out warnings);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            return base64String;
        }
        [WebMethod]
        public static List<CapaEntidades.ArticuloBodegaResult> GetAllArticulosBodega()
        {
            return ServiceArtBodega.GetAllArticulosBodega();
        }
        [WebMethod]
        public static List<CapaEntidades.ArticuloBodegaResult> GetAllArticulosBodegaReporte()
        {
            return ServiceArtBodega.GetAllArticulosBodegaReporte();
        }

        [WebMethod]
        public static List<ArtBodega> GetArticulosBodega()
        {
            return ServiceArtBodega.GetArticulosBodega();
        }
    }
}
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string ReporteVentas(CapaEntidades.ReporteRequest reporteRequest)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            var datos = ServiceVenta.ReportVentas();
            if (reporteRequest.FInicio != null && reporteRequest.FFinal != null)
            {
                datos = datos.Where(x => x.FechaVenta >= reporteRequest.FInicio.Value && x.FechaVenta <= reporteRequest.FFinal.Value).ToList();
            }
            else if (reporteRequest.FInicio != null) {
                datos = datos.Where(x => x.FechaVenta == reporteRequest.FInicio.Value).ToList();
            }
            var path = "./Reports/ReportVentas/ReportVentas.rdlc";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            ReportDataSource ds = new ReportDataSource("DataSet1", datos);
            localReport.DataSources.Add(ds);

            byte[] bytes = localReport.Render("PDF", null, out mimeType, out filenameExtension, out encoding, out streamids, out warnings);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        
            return base64String;
        }

        [WebMethod]
        public static List<CapaEntidades.Venta> ConsultarVentas()
        {
            return ServiceVenta.ConsultarVentas();
        }
        [WebMethod]
        public static List<CapaEntidades.ReportVentas> ReportVentas()
        {
            return ServiceVenta.ReportVentas();
        }
    }
}
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
    public partial class TipoMoneda : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public static ServiceTipoMoneda ServiceTipoMoneda { get; set; }
        public TipoMoneda()
        {
            _Context = new TiendaLitosEntities();
            ServiceTipoMoneda = new ServiceTipoMoneda(_Context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<CapaEntidades.TipoMoneda> GetAllTipoMoneda()
             => ServiceTipoMoneda.GetAllTipoMoneda();

        [WebMethod]
        public static CapaEntidades.TipoMoneda GetTipoMonedaById(int IdTipoMoneda)
            => ServiceTipoMoneda.GetTipoMonedaById(IdTipoMoneda);

        [WebMethod]
        public static Result CreateTipoMoneda(TIPOMONEDA tIPOMONEDA)
        {
            return ServiceTipoMoneda.CreateTipoMoneda(tIPOMONEDA);
        }

        [WebMethod]
        public static Result UpdateTipoMoneda(TIPOMONEDA tIPOMONEDA)
        {
            return ServiceTipoMoneda.UpdateTipoMoneda(tIPOMONEDA);
        }
    }
}
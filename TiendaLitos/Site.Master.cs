using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;

namespace TiendaLitos
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
                Response.Redirect("~/Pages/Logins.aspx");
            user.Text = "Usuario: " + Session["Usuario"].ToString();
        }
        protected void Salir(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pages/Logins.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;

namespace TiendaLitos.Pages
{
    public partial class Logins : System.Web.UI.Page
    {
        public TiendaLitosEntities _Context;
        public Logins()
        {
            _Context = new TiendaLitosEntities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                mensaje.Text = "";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var usuario = _Context.TbUsuario.FirstOrDefault(x => x.NombreUsuario == username.Text.Trim() && x.Contraseña == password.Text.Trim());
            if (usuario is null)
            {
                mensaje.Text = "Usuario y/o contraseña incorrectos.";
                return;
            }
            
            Session["usuario"] = $"{usuario.NombreUsuario} {usuario.Apellido}";
            Response.Redirect("~/Default.aspx");
        }
    }
}
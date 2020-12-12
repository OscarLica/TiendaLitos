using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaLitos.Context;

namespace TiendaLitos
{
    public partial class _Default : Page
    {
        public TiendaLitosEntities _Context { get; set; }
        public _Default()
        {
            if(Context is null)
            _Context = new TiendaLitosEntities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        
    }
} 
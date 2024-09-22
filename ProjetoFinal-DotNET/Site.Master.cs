using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal_DotNET
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["IdUsuario"] != null)
                {
                    profileLink.NavigateUrl = "~/Profile.aspx";
                    profileLink.Text = "Perfil";
                }
                else
                {
                    profileLink.NavigateUrl = "~/Login.aspx";
                    profileLink.Text = "Acesso";
                }
            }
        }
    }
}

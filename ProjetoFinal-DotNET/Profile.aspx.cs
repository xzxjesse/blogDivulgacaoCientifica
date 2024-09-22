using System;
using System.Web;

namespace ProjetoFinal_DotNET
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null && Session["NomeUsuario"] != null)
            {
                if (!IsPostBack)
                {
                    string userName = Session["NomeUsuario"].ToString();
                    UserNameLiteral.Text = userName;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
    }
}

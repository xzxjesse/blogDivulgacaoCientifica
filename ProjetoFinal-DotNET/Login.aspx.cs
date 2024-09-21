using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace ProjetoFinal_DotNET
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Visible = false;
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                lblMensagem.Text = "Preencha todos os campos.";
                lblMensagem.Visible = true;
                return;
            }

            int? idUsuario = await ValidarUsuario(email, senha);

            if (idUsuario != null)
            {
                lblMensagem.Visible = false;
                Session["IdUsuario"] = idUsuario;

                Response.Redirect("Profile.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
            }
            else
            {
                lblMensagem.Text = "E-mail ou senha inválidos.";
                lblMensagem.Visible = true;
            }
        }

        private async Task<int?> ValidarUsuario(string email, string senha)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://localhost:7259/api/Login/login?email={email}&senha={senha}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        if (int.TryParse(responseBody, out int idUsuario))
                        {
                            return idUsuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao validar o usuário: " + ex.Message;
                lblMensagem.Visible = true;
            }

            return null;
        }
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
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

            bool isAutenticado = await ValidarUsuario(email, senha);

            if (isAutenticado)
            {
                lblMensagem.Visible = false;
                // feed logado
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensagem.Text = "E-mail ou senha inválidos.";
                lblMensagem.Visible = true;
            }
        }

        private async Task<bool> ValidarUsuario(string email, string senha)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string apiUrl = $"https://localhost:7259/api/Login?email={email}&senha={senha}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return true; 
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao validar o usuário: " + ex.Message;
                lblMensagem.Visible = true;
                return false;
            }
        }
    }
}

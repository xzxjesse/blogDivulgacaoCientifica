using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

namespace ProjetoFinal_DotNET
{
    public partial class SignIn : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Visible = false;
        }

        protected async void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                lblMensagem.Text = "Preencha todos os campos.";
                lblMensagem.Visible = true;
                return;
            }

            int? userId = await CadastrarUsuario(nome, email, senha);

            if (userId != null)
            {
                lblMensagem.Text = "Cadastro realizado com sucesso!";
                lblMensagem.CssClass = "text-success";
                lblMensagem.Visible = true;

                Response.Redirect($"Profile.aspx?userId={userId}", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblMensagem.Text = "Erro ao cadastrar o usuário. Verifique os dados e tente novamente.";
                lblMensagem.Visible = true;
            }
        }

        private async Task<int?> CadastrarUsuario(string nome, string email, string senha)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var usuario = new
                    {
                        Nome = nome,
                        Email = email,
                        Senha = senha
                    };
                    var json = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string apiUrl = "https://localhost:7259/api/Login/cadastro";
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        int userId = JsonConvert.DeserializeObject<int>(responseContent);
                        return userId;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao cadastrar o usuário: " + ex.Message;
                lblMensagem.Visible = true;
                return null;
            }
        }
    }
}

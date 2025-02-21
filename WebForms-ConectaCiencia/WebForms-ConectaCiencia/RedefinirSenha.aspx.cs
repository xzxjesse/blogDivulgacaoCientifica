using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace WebForms_ConectaCiencia
{
    public partial class RedefinirSenha : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = Request.QueryString["token"];

                if (string.IsNullOrEmpty(token))
                {
                    lblMensagem.Text = "Token inválido.";
                    lblMensagem.Visible = true;
                    btnRedefinir.Enabled = false;
                }
                else
                {
                    if (!VerificarTokenNoBanco(token))
                    {
                        lblMensagem.Text = "Token inválido ou expirado.";
                        lblMensagem.Visible = true;
                        btnRedefinir.Enabled = false;
                    }
                }
            }
        }

        protected void btnRedefinir_Click(object sender, EventArgs e)
        {
            string novaSenha = txtNovaSenha.Text.Trim();
            string confirmarSenha = txtConfirmarSenha.Text.Trim();

            if (novaSenha != confirmarSenha)
            {
                lblMensagem.Text = "As senhas não coincidem.";
                lblMensagem.Visible = true;
                return;
            }

            string token = Request.QueryString["token"];

            if (AtualizarSenhaNoBanco(token, novaSenha))
            {
                lblMensagem.Text = "Senha redefinida com sucesso!";
                lblMensagem.Visible = true;
                btnRedefinir.Enabled = false;
            }
            else
            {
                lblMensagem.Text = "Erro ao redefinir a senha.";
                lblMensagem.Visible = true;
            }
        }

        // API
        private bool VerificarTokenNoBanco(string token)
        {
            string connectionString = "connectionStrings";
            string query = "SELECT COUNT(*) FROM Usuarios WHERE TokenRedefinicao = @Token AND TokenExpiracao > @DataAtual";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.Parameters.AddWithValue("@DataAtual", DateTime.Now);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //API
        private bool AtualizarSenhaNoBanco(string token, string novaSenha)
        {
            string connectionString = "connectionStrings"; 
            string query = "UPDATE Usuarios SET Senha = @NovaSenha, TokenRedefinicao = NULL, TokenExpiracao = NULL WHERE TokenRedefinicao = @Token";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NovaSenha", novaSenha); 
                    cmd.Parameters.AddWithValue("@Token", token);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
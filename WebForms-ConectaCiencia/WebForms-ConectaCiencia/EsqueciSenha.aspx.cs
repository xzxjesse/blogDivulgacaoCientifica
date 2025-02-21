using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace WebForms_ConectaCiencia
{
    public partial class EsqueciSenha : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensagem.Visible = false;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblMensagem.Text = "Por favor, insira seu e-mail.";
                lblMensagem.Visible = true;
                return;
            }

            if (!VerificarEmailNoBanco(email))
            {
                lblMensagem.Text = "E-mail não encontrado.";
                lblMensagem.Visible = true;
                return;
            }

            string token = Guid.NewGuid().ToString();

            if (SalvarTokenNoBanco(email, token))
            {
                EnviarEmailRedefinicaoSenha(email, token);

                lblMensagem.Text = "Um e-mail com instruções foi enviado para o seu endereço.";
                lblMensagem.Visible = true;
            }
            else
            {
                lblMensagem.Text = "Erro ao processar a solicitação. Tente novamente.";
                lblMensagem.Visible = true;
            }
        }

        // API
        private bool VerificarEmailNoBanco(string email)
        {
            string connectionString = "connectionStrings";
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // API
        private bool SalvarTokenNoBanco(string email, string token)
        {
            string connectionString = "connectionStrings"; 
            string query = "UPDATE Usuarios SET TokenRedefinicao = @Token, TokenExpiracao = @Expiracao WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Token", token);
                    cmd.Parameters.AddWithValue("@Expiracao", DateTime.Now.AddHours(1)); 
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void EnviarEmailRedefinicaoSenha(string email, string token)
        {
            try
            {
                string urlRedefinicao = $"https://seusite.com/RedefinirSenha.aspx?token={HttpUtility.UrlEncode(token)}";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("no-reply@seusite.com");
                mail.To.Add(email);
                mail.Subject = "Redefinição de Senha";
                mail.Body = $"Clique no link abaixo para redefinir sua senha:<br><a href='{urlRedefinicao}'>{urlRedefinicao}</a>";
                mail.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.seusite.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential("seu-email@seusite.com", "sua-senha");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao enviar o e-mail: " + ex.Message;
                lblMensagem.Visible = true;
            }
        }
    }
}
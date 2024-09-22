using ProjetoFinal_DotNET.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal_DotNET
{
    public partial class MeusArtigos : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    await BindArtigos();
                }));
            }
        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicar.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private async Task CarregarArtigos()
        {
            try
            {
                var idUsuario = Session["IdUsuario"]?.ToString();
                if (string.IsNullOrEmpty(idUsuario))
                {
                    lblMensagem.Text = "Usuário não está logado.";
                    lblMensagem.Visible = true;
                    return;
                }

                string apiUrl = $"https://localhost:7259/api/Feed/MeusArtigos?id_usuario={idUsuario}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var artigos = await response.Content.ReadFromJsonAsync<List<Artigo>>();

                    if (artigos != null && artigos.Count > 0)
                    {
                        lblMensagem.Visible = false;
                        ArticlesRepeater.DataSource = artigos;
                        ArticlesRepeater.DataBind();
                    }
                    else
                    {
                        lblMensagem.Text = "Nenhum artigo encontrado.";
                        lblMensagem.Visible = true;
                        ArticlesRepeater.DataSource = null;
                        ArticlesRepeater.DataBind();
                    }
                }
                else
                {
                    lblMensagem.Text = $"Erro ao buscar artigos: {response.ReasonPhrase}";
                    lblMensagem.Visible = true;
                    ArticlesRepeater.DataSource = null;
                    ArticlesRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro: " + ex.Message;
                lblMensagem.Visible = true;
                ArticlesRepeater.DataSource = null;
                ArticlesRepeater.DataBind();
            }
        }

        private async Task BindArtigos()
        {
            await CarregarArtigos();
        }
    }
}

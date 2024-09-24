﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal_DotNET.Model;

namespace ProjetoFinal_DotNET
{
    public partial class MeusArtigos : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null || Session["NomeUsuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            if (!IsPostBack)
            {
                RegisterAsyncTask(new PageAsyncTask(async () =>
                {
                    await CarregarCategorias();
                    await BindArtigos();
                }));
            }
        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicar.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private async Task CarregarCategorias()
        {
            try
            {
                string apiUrl = "https://localhost:7259/api/Categoria";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var categorias = await response.Content.ReadFromJsonAsync<List<Categoria>>();
                    ddlCategorias.DataSource = categorias;
                    ddlCategorias.DataTextField = "Nome_Categoria";
                    ddlCategorias.DataValueField = "Id_Categoria";
                    ddlCategorias.DataBind();
                }
                else
                {
                    lblMensagem.Text = $"Erro ao carregar categorias: {response.ReasonPhrase}";
                    lblMensagem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro: " + ex.Message;
                lblMensagem.Visible = true;
            }
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
                        lblMensagem.Text = "Sem artigos publicados ainda, que tal fazer uma publicação?";
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

        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var artigoId = Convert.ToInt32(hfArtigoId.Value);
                var titulo = txtTitulo.Text.Trim();
                var conteudo = txtConteudo.Text.Trim();
                var categoriaId = Convert.ToInt32(ddlCategorias.SelectedValue);
                var nomeCategoria = ddlCategorias.SelectedItem.Text;

                var artigoModel = new Artigo
                {
                    Id_Artigo = artigoId,
                    Data = DateTime.UtcNow,
                    Titulo = titulo,
                    Conteudo = conteudo,
                    Categoria = new Categoria
                    {
                        Id_Categoria = categoriaId,
                        Nome_Categoria = nomeCategoria
                    },
                    Usuario = new UsuarioSimplificado
                    {
                        Id_Usuario = (int)Session["IdUsuario"],
                        Nome = (string)Session["NomeUsuario"]
                    }
                };

                string apiUrl = $"https://localhost:7259/api/Feed/Artigo/Patch/{artigoId}";
                var response = await client.PatchAsJsonAsync(apiUrl, artigoModel);

                if (response.IsSuccessStatusCode)
                {
                    lblMensagem.Text = "Artigo atualizado com sucesso.";
                    lblMensagem.Visible = true;
                    await BindArtigos();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    lblMensagem.Text = $"Erro ao atualizar artigo: {response.ReasonPhrase} - {errorContent}";
                    lblMensagem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro: " + ex.Message;
                lblMensagem.Visible = true;
            }
        }

        protected async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var artigoId = Convert.ToInt32((sender as Button).CommandArgument);
                string apiUrl = $"https://localhost:7259/api/Feed/Artigo/Delete/{artigoId}";

                var response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    lblMensagem.Text = "Artigo excluído com sucesso.";
                    lblMensagem.Visible = true;
                    await BindArtigos();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    lblMensagem.Text = $"Erro ao excluir artigo: {response.ReasonPhrase} - {errorContent}";
                    lblMensagem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro: " + ex.Message;
                lblMensagem.Visible = true;
            }
        }
    }
}

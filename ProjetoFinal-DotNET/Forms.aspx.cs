using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFinal_DotNET.Dao.Domain;
using ProjetoFinal_DotNET.Dao.Repositor;
using ProjetoFinal_DotNET.Dao.Repository;
using static ProjetoFinal_DotNET.Dao.Domain.Formularios;

namespace ProjetoFinal_DotNET
{
    public partial class Forms : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCategorias();
            }
        }

        private void CarregarCategorias()
        {
            CategoriaRepository categoriaRepo = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepo.ObterTodasCategorias();

            ddlCategoriaTema.DataSource = categorias;
            ddlCategoriaTema.DataTextField = "Nome_Categoria";
            ddlCategoriaTema.DataValueField = "Id_Categoria";
            ddlCategoriaTema.DataBind();
            ddlCategoriaTema.Items.Insert(0, new ListItem("Selecione uma Categoria", "0"));

            ddlCategoriaArtigo.DataSource = categorias;
            ddlCategoriaArtigo.DataTextField = "Nome_Categoria";
            ddlCategoriaArtigo.DataValueField = "Id_Categoria";
            ddlCategoriaArtigo.DataBind();
            ddlCategoriaArtigo.Items.Insert(0, new ListItem("Selecione uma Categoria", "0"));
        }

        protected void BtnEnviarTema_Click(object sender, EventArgs e)
        {
            string nome = txtNomeTema.Text.Trim();
            string email = txtEmailTema.Text.Trim();
            string tema = txtTema.Text.Trim();
            int idCategoria = int.Parse(ddlCategoriaTema.SelectedValue);

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(tema) || idCategoria == 0)
            {
                ExibirMensagem("alertError", "Todos os campos são obrigatórios e uma categoria deve ser selecionada.");
                return;
            }

            try
            {
                FormulariosRepository formulariosRepo = new FormulariosRepository();
                FormularioTema formularioTema = new FormularioTema
                {
                    Nome = nome,
                    Email = email,
                    Tema = tema,
                    Id_Categoria = idCategoria
                };
                formulariosRepo.AdicionarTema(formularioTema);

                LimparCamposTema();
                ExibirMensagem("alertSuccess", "Sugestão de tema enviada com sucesso!");
            }
            catch (Exception ex)
            {
                ExibirMensagem("alertError", "Erro ao salvar dados: " + ex.Message);
            }
        }

        protected void BtnEnviarArtigo_Click(object sender, EventArgs e)
        {
            string nome = txtNomeArtigo.Text.Trim();
            string email = txtEmailArtigo.Text.Trim();
            string titulo = txtTituloArtigo.Text.Trim();
            string conteudo = txtConteudoArtigo.Text.Trim();
            int idCategoria = int.Parse(ddlCategoriaArtigo.SelectedValue);

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(conteudo) || idCategoria == 0)
            {
                ExibirMensagem("alertError", "Todos os campos são obrigatórios e uma categoria deve ser selecionada.");
                return;
            }

            try
            {
                FormulariosRepository formulariosRepo = new FormulariosRepository();
                FormularioArtigo formularioArtigo = new FormularioArtigo
                {
                    Nome = nome,
                    Email = email,
                    Titulo = titulo,
                    Conteudo = conteudo,
                    Id_Categoria = idCategoria
                };
                formulariosRepo.AdicionarArtigo(formularioArtigo);

                LimparCamposArtigo();
                ExibirMensagem("alertSuccess", "Sugestão de artigo enviada com sucesso!");
            }
            catch (Exception ex)
            {
                ExibirMensagem("alertError", "Erro ao salvar dados: " + ex.Message);
            }
        }

        private void ExibirMensagem(string idAlert, string mensagem)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", $"mostrarMensagem('{idAlert}', '{mensagem}');", true);
        }

        private void LimparCamposTema()
        {
            txtNomeTema.Text = "";
            txtEmailTema.Text = "";
            txtTema.Text = "";
            ddlCategoriaTema.SelectedIndex = 0;
        }

        private void LimparCamposArtigo()
        {
            txtNomeArtigo.Text = "";
            txtEmailArtigo.Text = "";
            txtTituloArtigo.Text = "";
            txtConteudoArtigo.Text = "";
            ddlCategoriaArtigo.SelectedIndex = 0;
        }
    }
}

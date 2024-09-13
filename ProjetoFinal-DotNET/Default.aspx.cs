using ProjetoFinal_DotNET.Service;
using ProjetoFinal_DotNET.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Web.UI;
using ProjetoFinal_DotNET.Dao.Repository;
using System.Web.UI.WebControls;

namespace ProjetoFinal_DotNET
{
    public partial class _Default : Page
    {
        private ArtigoService _artigoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_artigoService == null)
            {
                _artigoService = new ArtigoService(new ArtigoRepository());
            }

            if (!IsPostBack)
            {
                CarregarCategorias();
                BindArtigos();
            }
        }

        private void CarregarCategorias()
        {
            try
            {
                CategoriaRepository categoriaRepository = new CategoriaRepository();
                List<Categoria> categorias = categoriaRepository.ObterTodasCategorias();

                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataTextField = "nome_categoria";
                ddlCategoria.DataValueField = "id_categoria";
                ddlCategoria.DataBind();

                ddlCategoria.Items.Insert(0, new ListItem("Selecione uma Categoria", ""));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar as categorias", ex);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (_artigoService == null)
            {
                _artigoService = new ArtigoService(new ArtigoRepository());
            }

            string textoPesquisa = txtTextoPesquisa.Text.Trim();
            string nomeCategoria = ddlCategoria.SelectedItem.Text;

            if (ddlCategoria.SelectedIndex == 0)
            {
                nomeCategoria = null;
            }

            List<Artigo> artigos = _artigoService.PesquisarArtigos(textoPesquisa, nomeCategoria);

            ArticlesRepeater.DataSource = artigos;
            ArticlesRepeater.DataBind();
        }

        private void BindArtigos()
        {
            List<Artigo> artigos = _artigoService.ObterTodosArtigos();
            ArticlesRepeater.DataSource = artigos;
            ArticlesRepeater.DataBind();
        }
    }
}

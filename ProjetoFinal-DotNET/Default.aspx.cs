using System;
using System.Collections.Generic;
using ProjetoFinal_DotNET.Dao.Domain;
using ProjetoFinal_DotNET.Service;

using ProjetoFinal_DotNET.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal_DotNET
{
    public partial class _Default : System.Web.UI.Page
    {
        private ArtigoService _artigoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _artigoService = (ArtigoService)Application["ArtigoService"];
                BindArticles();
            }
        }

        private void BindArticles()
        {
            var artigos = _artigoService.ObterTodosArtigos();
            ArticlesRepeater.DataSource = artigos;
            ArticlesRepeater.DataBind();
        }
    }
}

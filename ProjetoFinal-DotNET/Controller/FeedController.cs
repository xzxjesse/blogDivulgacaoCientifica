using ProjetoFinal_DotNET.Dao.Domain;
using ProjetoFinal_DotNET.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Controller
{
    public class FeedController
    {
        private readonly ArtigoRepository _artigoRepository;

        public FeedController(ArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        public List<Artigo> ObterTodosArtigos()
        {
            try
            {
                return _artigoRepository.Pesquisa(null, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os artigos", ex);
            }
        }

        public List<Artigo> PesquisarArtigos(string textoPesquisa, string nomeCategoria, DateTime? dataPublicacao)
        {
            return _artigoRepository.Pesquisa(textoPesquisa, nomeCategoria, dataPublicacao);
        }
    }
}
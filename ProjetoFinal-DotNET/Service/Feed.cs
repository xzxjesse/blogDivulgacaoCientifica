using ProjetoFinal_DotNET.Dao.Domain;
using ProjetoFinal_DotNET.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Service
{
    public class ArtigoService
    {
        private readonly ArtigoRepository _artigoRepository;

        public ArtigoService(ArtigoRepository artigoRepository)
        {
            _artigoRepository = artigoRepository;
        }

        public List<Artigo> ObterTodosArtigos()
        {
            try
            {
                return _artigoRepository.Pesquisa(null, null); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os artigos", ex);
            }
        }

        public List<Artigo> PesquisarArtigos(int? idArtigo, string titulo)
        {
            try
            {
                return _artigoRepository.Pesquisa(idArtigo, titulo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar artigos", ex);
            }
        }

    }
}
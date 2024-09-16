using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Dao.Domain
{
    public class Artigo
    {
        public int Id_Artigo { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        
        public string Nome { get; set; }

        public int Id_Categoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
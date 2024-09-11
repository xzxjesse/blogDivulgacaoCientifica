using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Dao.Domain
{
    public class Artigo
    {
        public int id_artigo { get; set; }
        public DateTime data { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        
        public string nome { get; set; }
    }
}
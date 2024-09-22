using ProjetoFinal_DotNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Model
{
    public class Artigo
    {
        public int Id_Artigo { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public UsuarioSimplificado Usuario { get; set; }
        public Categoria Categoria { get; set; }
    }
}
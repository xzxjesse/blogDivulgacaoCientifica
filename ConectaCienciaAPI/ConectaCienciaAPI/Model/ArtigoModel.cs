using ConectaCienciaAPI.Model;

namespace ConectaCienciaAPI.Models
{
    public class ArtigoModel
    {
        public int Id_Artigo { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public UsuarioModel Usuario { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}

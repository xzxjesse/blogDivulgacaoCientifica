namespace API_ProjetoFinal_DotNET.Models
{
    public class ArtigoModel
    {
        public int Id_Artigo { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public string Nome { get; set; }

        public int Id_Categoria { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}

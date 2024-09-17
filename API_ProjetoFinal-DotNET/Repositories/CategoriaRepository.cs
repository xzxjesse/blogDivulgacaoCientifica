using System.Collections.Generic;
using System.Data.SqlClient;
using API_ProjetoFinal_DotNET.Models;

namespace API_ProjetoFinal_DotNET.Repositories
{
    public class CategoriaRepository
    {
        private readonly string _connectionString;

        public CategoriaRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("ConnectionString sem valor válido");
            }
            _connectionString = connectionString;
        }

        public IEnumerable<CategoriaModel> ObterTodasCategorias()
        {
            string sql = "SELECT * FROM Categorias";

            List<CategoriaModel> categorias = new List<CategoriaModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        CategoriaModel categoria = new CategoriaModel
                        {
                            Id_Categoria = dataReader.GetInt32(dataReader.GetOrdinal("id_categoria")),
                            Nome_Categoria = dataReader.GetString(dataReader.GetOrdinal("nome_categoria"))
                        };

                        categorias.Add(categoria);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar categorias", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return categorias;
        }
    }
}

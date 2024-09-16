using ProjetoFinal_DotNET.Dao.Config;
using ProjetoFinal_DotNET.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Dao.Repository
{
    public class CategoriaRepository
    {
        public List<Categoria> ObterTodasCategorias()
        {
            string sql = "SELECT * FROM Categorias";

            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Categoria categoria = new Categoria
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
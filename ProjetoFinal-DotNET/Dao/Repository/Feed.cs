using ProjetoFinal_DotNET.Dao.Config;
using ProjetoFinal_DotNET.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal_DotNET.Dao.Repository
{
    public class ArtigoRepository
    {
        public List<Artigo> Pesquisa(int? idArtigo, string titulo)
        {
            string sql = @"SELECT * FROM Artigos ORDER BY data DESC;";

            List<Artigo> artigos = new List<Artigo>();
            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Artigo artigo = new Artigo
                        {
                            id_artigo = dataReader.GetInt32(dataReader.GetOrdinal("id_artigo")),
                            data = dataReader.GetDateTime(dataReader.GetOrdinal("data")),
                            titulo = dataReader.GetString(dataReader.GetOrdinal("titulo")),
                            conteudo = dataReader.GetString(dataReader.GetOrdinal("conteudo")),
                            nome = dataReader.GetString(dataReader.GetOrdinal("nome")),
                        };

                        artigos.Add(artigo);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar artigos", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return artigos;
        }
    }
}
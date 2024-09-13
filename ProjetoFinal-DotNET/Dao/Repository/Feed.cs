﻿using ProjetoFinal_DotNET.Dao.Config;
using ProjetoFinal_DotNET.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjetoFinal_DotNET.Dao.Repository
{
    public class ArtigoRepository
    {
        public List<Artigo> Pesquisa(string textoPesquisa, string nomeCategoria, DateTime? dataPublicacao)
        {
            string sql = @"SELECT a.*, c.nome_categoria 
                       FROM Artigos a
                       JOIN Categorias c ON a.id_categoria = c.id_categoria
                       WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(textoPesquisa))
            {
                sql += " AND (a.titulo LIKE @textoPesquisa OR a.conteudo LIKE @textoPesquisa)";
                parameters.Add(new SqlParameter("@textoPesquisa", "%" + textoPesquisa + "%"));
            }

            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                sql += " AND c.nome_categoria LIKE @nomeCategoria";
                parameters.Add(new SqlParameter("@nomeCategoria", "%" + nomeCategoria + "%"));
            }

            if (dataPublicacao.HasValue)
            {
                sql += " AND CAST(a.data AS DATE) = @dataPublicacao";
                parameters.Add(new SqlParameter("@dataPublicacao", dataPublicacao.Value.Date));
            }

            sql += " ORDER BY a.data DESC";

            List<Artigo> artigos = new List<Artigo>();

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddRange(parameters.ToArray());

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Artigo artigo = new Artigo
                        {
                            Id_Artigo = dataReader.GetInt32(dataReader.GetOrdinal("id_artigo")),
                            Data = dataReader.GetDateTime(dataReader.GetOrdinal("data")),
                            Titulo = dataReader.GetString(dataReader.GetOrdinal("titulo")),
                            Conteudo = dataReader.GetString(dataReader.GetOrdinal("conteudo")),
                            Nome = dataReader.GetString(dataReader.GetOrdinal("nome_categoria"))
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

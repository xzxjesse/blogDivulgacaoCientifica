using ProjetoFinal_DotNET.Dao.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static ProjetoFinal_DotNET.Dao.Domain.Formularios;

namespace ProjetoFinal_DotNET.Dao.Repositor
{
    public class FormulariosRepository
    {
        public void AdicionarTema(FormularioTema formularioTema)
        {
            if (string.IsNullOrWhiteSpace(formularioTema.Nome))
                throw new ArgumentException("Nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(formularioTema.Email))
                throw new ArgumentException("Email é obrigatório.");
            if (string.IsNullOrWhiteSpace(formularioTema.Tema))
                throw new ArgumentException("Tema é obrigatório.");

            string sql = @"INSERT INTO FormularioTema (nome, email, tema, id_categoria)
                           VALUES (@nome, @email, @tema, @id_categoria)";

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nome", formularioTema.Nome);
                        command.Parameters.AddWithValue("@email", formularioTema.Email);
                        command.Parameters.AddWithValue("@tema", formularioTema.Tema);
                        command.Parameters.AddWithValue("@id_categoria", (object)formularioTema.Id_Categoria ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao adicionar formulário de tema", ex);
                }
            }
        }

        public void AdicionarArtigo(FormularioArtigo formularioArtigo)
        {
            if (string.IsNullOrWhiteSpace(formularioArtigo.Nome))
                throw new ArgumentException("Nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(formularioArtigo.Email))
                throw new ArgumentException("Email é obrigatório.");
            if (string.IsNullOrWhiteSpace(formularioArtigo.Titulo))
                throw new ArgumentException("Título é obrigatório.");
            if (string.IsNullOrWhiteSpace(formularioArtigo.Conteudo))
                throw new ArgumentException("Conteúdo é obrigatório.");

            string sql = @"INSERT INTO FormularioArtigo (nome, email, titulo, conteudo, id_categoria)
                           VALUES (@nome, @email, @titulo, @conteudo, @id_categoria)";

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nome", formularioArtigo.Nome);
                        command.Parameters.AddWithValue("@email", formularioArtigo.Email);
                        command.Parameters.AddWithValue("@titulo", formularioArtigo.Titulo);
                        command.Parameters.AddWithValue("@conteudo", formularioArtigo.Conteudo);
                        command.Parameters.AddWithValue("@id_categoria", (object)formularioArtigo.Id_Categoria ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao adicionar formulário de artigo", ex);
                }
            }
        }
    }
}
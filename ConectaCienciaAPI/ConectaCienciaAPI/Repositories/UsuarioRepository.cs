using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ConectaCienciaAPI.Model;

namespace ConectaCienciaAPI.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("ConnectionString sem valor válido");
            }
            _connectionString = connectionString;
        }

        public IEnumerable<UsuarioModel> ObterUsuariosPorEmailESenha(string email, string senha)
        {
            var usuarios = new List<UsuarioModel>();
            var sql = @"SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Senha", senha)
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarios.Add(new UsuarioModel
                                {
                                    Id_Usuario = reader.GetInt32(reader.GetOrdinal("Id_Usuario")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Senha = reader.GetString(reader.GetOrdinal("Senha"))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }

            return usuarios;
        }

        public void AdicionarUsuario(UsuarioModel usuario)
        {
            var sql = @"INSERT INTO Usuarios (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Nome", usuario.Nome),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Senha", usuario.Senha) 
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados.", ex);
            }
        }
    }
}

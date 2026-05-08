using FlowDesk.DTOs;
using FlowDesk.Interfaces;
using MySql.Data.MySqlClient;

namespace FlowDesk.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao")!;
        }

        public UsuarioViewModel? Validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT * FROM tb_Usuario WHERE Email = @email";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string senhaBanco = reader["Senha"].ToString()!;

                if (BCrypt.Net.BCrypt.Verify(senha, senhaBanco))
                {
                    return new UsuarioViewModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        Nivel = reader["Nivel"].ToString()!
                    };
                }
            }
            return null;
        }

        public void CriarConta(CriarContaDto usuario)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            var sql = "INSERT INTO tb_Usuario(Nome, Email, Senha, Nivel) VALUES (@nome, @email, @senha, @nivel)";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", senhaHash);
            cmd.Parameters.AddWithValue("@nivel", "usuario");
            cmd.ExecuteNonQuery();
        }
    }
}
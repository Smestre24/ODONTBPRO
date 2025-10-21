using MySql.Data.MySqlClient;
using Projeto_Odontpro.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Projeto_Odontpro.Services
{
    public class FuncionarioDAO
    {
        private readonly string connectionString = "server=localhost;database=pds_app_web;user=root;password=root;";

        public FuncionarioDAO(string connString = null)
        {
            if (!string.IsNullOrEmpty(connString))
                connectionString = connString;
        }

        // Listar todos os funcionários
        public async Task<List<Funcionario>> ObterTodos()
        {
            var lista = new List<Funcionario>();
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM funcionarios";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new Funcionario
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email"),
                    Telefone = reader.GetString("Telefone"),
                    Cargo = reader.GetString("Cargo"),
                    Estado = reader["Estado"]?.ToString()
                });
            }

            return lista;
        }

        // Obter funcionário por ID
        public async Task<Funcionario?> ObterPorId(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = "SELECT * FROM funcionarios WHERE Id=@id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Funcionario
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome"),
                    Email = reader.GetString("Email"),
                    Telefone = reader.GetString("Telefone"),
                    Cargo = reader.GetString("Cargo"),
                    Estado = reader["Estado"]?.ToString()
                };
            }

            return null;
        }

        // Adicionar novo funcionário
        public async Task Adicionar(Funcionario f)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = @"INSERT INTO funcionarios (Nome, Email, Telefone, Cargo, Estado)
                             VALUES (@nome, @email, @telefone, @cargo, @estado)";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nome", f.Nome);
            cmd.Parameters.AddWithValue("@email", f.Email);
            cmd.Parameters.AddWithValue("@telefone", f.Telefone);
            cmd.Parameters.AddWithValue("@cargo", f.Cargo);
            cmd.Parameters.AddWithValue("@estado", f.Estado);

            await cmd.ExecuteNonQueryAsync();
        }

        // Atualizar funcionário existente
        public async Task Atualizar(Funcionario f)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = @"UPDATE funcionarios 
                             SET Nome=@nome, Email=@email, Telefone=@telefone, Cargo=@cargo, Estado=@estado
                             WHERE Id=@id";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nome", f.Nome);
            cmd.Parameters.AddWithValue("@email", f.Email);
            cmd.Parameters.AddWithValue("@telefone", f.Telefone);
            cmd.Parameters.AddWithValue("@cargo", f.Cargo);
            cmd.Parameters.AddWithValue("@estado", f.Estado);
            cmd.Parameters.AddWithValue("@id", f.Id);

            await cmd.ExecuteNonQueryAsync();
        }

        // Excluir funcionário
        public async Task Excluir(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();

            string query = "DELETE FROM funcionarios WHERE Id=@id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}

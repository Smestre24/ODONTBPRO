using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Projeto_Odontpro.Components;
using Projeto_Odontpro.Models;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Projeto_Odontpro.Services
{
    public class PacienteService
    {

        private readonly string connectionString;

        public PacienteService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public async Task<List<Paciente>> ObterTodos()
        {
            var lista = new List<Paciente>();

            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string sql = "SELECT * FROM Clientes";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Paciente
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email"),
                            Telefone = reader.GetString("Telefone"),
                            Endereco = reader.GetString("Endereco")
                        });
                    }
                }
            }

            return lista;
        }

        public async Task Adicionar(Paciente pacientes)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string sql = "INSERT INTO Clientes (Nome, Email, Telefone, Endereco) VALUES (@nome, @email, @telefone, @endereco)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", pacientes.Nome);
                    cmd.Parameters.AddWithValue("@email", pacientes.Email);
                    cmd.Parameters.AddWithValue("@telefone", pacientes.Telefone);
                    cmd.Parameters.AddWithValue("@endereco", pacientes.Endereco);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Excluir(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string sql = "DELETE FROM Clientes WHERE Id=@id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

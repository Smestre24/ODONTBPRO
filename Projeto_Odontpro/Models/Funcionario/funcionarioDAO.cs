using MySql.Data.MySqlClient;
using Projeto_Odontpro.Configs;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Projeto_Odontpro.Models.Funcionario
{
    public class FuncionarioDAO
    {

        //Todo arquivo terminado em DAO vai ter essas linhas no topo (obrigatorio!)
        private readonly Conexao _conexao;

        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }
        // ------- até aqui ----------


        // NÃO UTILISE CODIGO ASSINCRONO (async), se o chat gerar qualquer coisa com isso, provavelmente é desnecessario
        //public async Task<List<Funcionario>> ObterTodos()
        //{
        //    var lista = new List<Funcionario>();
        //    using var conn = new MySqlConnection(connectionString);
        //    await conn.OpenAsync();

        //    string query = "SELECT * FROM funcionarios";
        //    using var cmd = new MySqlCommand(query, conn);
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    while (await reader.ReadAsync())
        //    {
        //        lista.Add(new Funcionario
        //        {
        //            Id = reader.GetInt32("Id"),
        //            Nome = reader.GetString("Nome"),
        //            Email = reader.GetString("Email"),
        //            Telefone = reader.GetString("Telefone"),
        //            Cargo = reader.GetString("Cargo"),
        //            Estado = reader["Estado"]?.ToString()
        //        });
        //    }

        //    return lista;
        //}

        public List<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>();

            //atualizar isso pra tabela funcionario

            //var comando = _conexao.CreateCommand("SELECT * FROM funcionario;");
            //var leitor = comando.ExecuteReader();

            //while (leitor.Read())
            //{
            //    var paciente = new Funcionario();
            //    paciente.Id = leitor.GetInt32("id_func");
            //    paciente.Nome = DAOHelper.GetString(leitor, "nome_func");
            //    paciente.Sexo = DAOHelper.GetString(leitor, "sexo_func");
            //    paciente.Telefone = DAOHelper.GetString(leitor, "telefone_func");
            //    paciente.Nascimento = leitor.GetDateTime("data_nascimento_func");
            //    paciente.Estado = DAOHelper.GetString(leitor, "estado_func");
            //    paciente.Observacoes = DAOHelper.GetString(leitor, "observacoes_func");

            //    lista.Add(paciente);
            //}

            return lista;
        }

        public void Inserir(Funcionario paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "INSERT INTO Paciente VALUES (null, @_nome, @_sexo, @_telefone, @_dataNascimento, @_estado, @_observacoes)");

                comando.Parameters.AddWithValue("@_nome", paciente.Nome);
                comando.Parameters.AddWithValue("@_sexo", paciente.Sexo);
                comando.Parameters.AddWithValue("@_telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@_dataNascimento", paciente.Nascimento);
                comando.Parameters.AddWithValue("@_estado", paciente.Estado);
                comando.Parameters.AddWithValue("@_observacoes", paciente.Observacoes);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Excluir(int id)
        {

        }

    }
}

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

        //    string query = "SELECT * FROM funcionario";
        //    using var cmd = new MySqlCommand(query, conn);
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    while (await reader.ReadAsync())
        //    {
        //        lista.Add(new Funcionario
        //        {
        //            Id = reader.GetInt32("Id"),
        //            Nome = reader.GetString("Nome"),
        //            Email = reader.GetString("Email"),
        //            Sexo = reader.GetString("Sexo"),
        //            Telefone = reader.GetString("Telefone"),
        //            Cargo = reader.GetString("Cargo"),
        //            Estado = reader["Estado"]?.ToString(),
        //            Nacimento = reader.GetDateTime.ToString(),
        //            Endereco = reader.GetString("Endereco"),
        //            Salario = reader.GetDecimal("Salario"),
        //            Observacoes = reader.GetString("Observacoes")
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
            //    var funcionario = new Funcionario();
            //    funcionario.Id = leitor.GetInt32("id_func");
            //    funcionario.Nome = DAOHelper.GetString(leitor, "nome_func");
            //    funcionario.Email = DAOHelper.GetString(leitor, "email_func");
            //    funcionario.Sexo = DAOHelper.GetString(leitor, "sexo_func");
            //    funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_func");
            //    funcionario.Cargo = DAOHelper.GetString(leitor, "cargo_func");
            //    funcionario.Estado = DAOHelper.GetString(leitor, "estado_func");
            //    funcionario.Nascimento = leitor.GetDateTime("data_nascimento_func");
            //    funcionario.Endereco = DAOHelper.GetString(leitor, "endereco_func");
            //    funcionario.Salario = leitor.GetDecimal("salario_func");
            //    funcionario.Observacoes = DAOHelper.GetString(leitor, "observacoes_func");

            //    lista.Add(funcionario);
            //}

            return lista;
        }

        public void Inserir(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "INSERT INTO Funcionario VALUES (null, @_nome, @_email @_sexo, @_telefone, @_cargo, @_estado, @_dataNascimento, @_endereco, @_salario, @_observacoes)");

                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_email", funcionario.Nome);
                comando.Parameters.AddWithValue("@_sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_cargo", funcionario.Cargo);
                comando.Parameters.AddWithValue("@_estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@_dataNascimento", funcionario.Nascimento);
                comando.Parameters.AddWithValue("@_endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@_salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@_observacoes", funcionario.Observacoes);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Funcionario? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM funcionario WHERE id_func = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var funcionario = new Funcionario();
                funcionario.Id = leitor.GetInt32("id_func");
                funcionario.Nome = DAOHelper.GetString(leitor, "nome_func");
                funcionario.Email = DAOHelper.GetString(leitor, "email_func");
                funcionario.Sexo = DAOHelper.GetString(leitor, "sexo_func");
                funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_func");
                funcionario.Cargo = DAOHelper.GetString(leitor, "cargo_func");
                funcionario.Estado = DAOHelper.GetString(leitor, "estado_func");
                funcionario.Nascimento = leitor.GetDateTime("data_nascimento_func");
                funcionario.Endereco = DAOHelper.GetString(leitor, "endereco_func");
                funcionario.Salario = leitor.GetDecimal("salario_func");
                funcionario.Observacoes = DAOHelper.GetString(leitor, "observacoes_func");

                return funcionario;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE funcionario SET nome_func = @nome, email_func = @email, sexo_func = @sexo, telefone_func = @telefone, cargo_func = @cargo, estado_func = @estado, nascimento_func = @dataNascimento, endereco_func = @endereco, salario_func = @salario, observacoes_func = @observacoes " +
                    "WHERE id_func = @id;");

                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@email", funcionario.Nome);
                comando.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@dataNascimento", funcionario.Nascimento);
                comando.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@observacoes", funcionario.Observacoes);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "DELETE FROM funcionario WHERE id_func = @id;");

                comando.Parameters.AddWithValue("@id", id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

    }
}

using Projeto_Odontpro.Configs;

namespace Projeto_Odontpro.Models.Funcionario
{
    public class ColaboradorDAO
    {
        private readonly Conexao _conexao;

        public ColaboradorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM Colaborador;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var colaborador = new Funcionario();
                colaborador.Id = leitor.GetInt32("id_col");
                colaborador.Nome = DAOHelper.GetString(leitor, "nome_col");
                colaborador.Sexo = DAOHelper.GetString(leitor, "sexo_col");
                colaborador.Telefone = DAOHelper.GetString(leitor, "telefone_col");
                colaborador.Nascimento = leitor.GetDateTime("data_nascimento_col");
                colaborador.Estado = DAOHelper.GetString(leitor, "estado_col");
                colaborador.Endereco = DAOHelper.GetString(leitor, "endereco_col");
                colaborador.Observacoes = DAOHelper.GetString(leitor, "observacoes_col");

                lista.Add(colaborador);
            }

            return lista;
        }

        public void Inserir(Funcionario colaborador)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "INSERT INTO Colaborador VALUES (null, @_nome, @_sexo, @_telefone, @_dataNascimento, @_estado, @_endereco, @_observacoes)");

                comando.Parameters.AddWithValue("@_nome", colaborador.Nome);
                comando.Parameters.AddWithValue("@_sexo", colaborador.Sexo);
                comando.Parameters.AddWithValue("@_telefone", colaborador.Telefone);
                comando.Parameters.AddWithValue("@_dataNascimento", colaborador.Nascimento);
                comando.Parameters.AddWithValue("@_estado", colaborador.Estado);
                comando.Parameters.AddWithValue("@_endereco", colaborador.Endereco);
                comando.Parameters.AddWithValue("@_observacoes", colaborador.Observacoes);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

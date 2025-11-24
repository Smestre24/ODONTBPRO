using Projeto_Odontpro.Configs;


namespace Projeto_Odontpro.Models.Paciente
{
    public class AtendimetoPacienteDAO
    {
        private readonly Conexao _conexao;

        public AtendimetoPacienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public Paciente? BuscarPorId(int id)
        {


            var comando = _conexao.CreateCommand(
                "SELECT * FROM produto WHERE id_pro = @id;");

            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var Atendimento = new Paciente();
                Atendimento.Id = leitor.GetInt32("Id_pac");
                Atendimento.Nome = DAOHelper.GetString(leitor, "Nome_pac");
                Atendimento.Email = DAOHelper.GetString(leitor, "Email_pac");
                Atendimento.Sexo = DAOHelper.GetString(leitor, "Sexo_pac");
                Atendimento.Telefone = DAOHelper.GetString(leitor, "Telefone_pac");
                Atendimento.Nascimento = leitor.GetDateTime("Nascimento_pac");
                Atendimento.Estado = DAOHelper.GetString(leitor, "Estado_pac");
                Atendimento.Endereco = DAOHelper.GetString(leitor, "Endereco_pac");
                Atendimento.Observacoes = DAOHelper.GetString(leitor, "Observacoes_pac");

                return Atendimento;
            }
            else
            {
                return null;
            }
        }

            public void Atualizar(Paciente atendimento)
            {
                try
                {
                    var comando = _conexao.CreateCommand(
                    "UPDATE paciente SET nome_pac = @_nome, Email_pac = @_email, " +
                    "Sexo_pac = @_sexo, Telefone_pac = @_telefone, Nascimento_pac = @_Nascimento, Estado_pac = @_estado, Endereco_pac = @_endereco, Observacoes_pac = @_observacoes  WHERE id_pac = @_id;");

                    comando.Parameters.AddWithValue("@_nome", atendimento.Nome);
                    comando.Parameters.AddWithValue("@_email", atendimento.Email);              
                    comando.Parameters.AddWithValue("@_sexo", atendimento.Sexo);
                    comando.Parameters.AddWithValue("@_telefone", atendimento.Telefone);
                    comando.Parameters.AddWithValue("@_Nascimento", atendimento.Nascimento);
                    comando.Parameters.AddWithValue("@_estado", atendimento.Estado);
                    comando.Parameters.AddWithValue("@_endereco", atendimento.Endereco);
                    comando.Parameters.AddWithValue("@_observacoes", atendimento.Observacoes);
                    comando.Parameters.AddWithValue("@_id", atendimento.Id);

                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        
    }
}

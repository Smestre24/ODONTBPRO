using Projeto_Odontpro.Configs;

namespace Projeto_Odontpro.Models
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
                Atendimento.Email = DAOHelper.GetString(leitor, "descricao_pro");
                Atendimento.Sexo = leitor.("quantidade_pro");
                Atendimento.Telefone = DAOHelper.GetString(leitor, "Telefone_pac");
                Atendimento.Nascimento = DAOHelper.GetDateTime(leitor,"Nascimento_pac");
                Atendimento.Estado=  leitor;
                Atendimento.Endereco = leitor;
                Atendimento.Observacoes

                return produto;
            }
            else
            {
                return null;
            }
        }
    }
}

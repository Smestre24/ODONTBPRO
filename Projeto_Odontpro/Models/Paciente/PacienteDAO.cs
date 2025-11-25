using Projeto_Odontpro.Configs;

namespace Projeto_Odontpro.Models.Paciente
{
    public class PacienteDAO
    {
        private readonly Conexao _conexao;

        public PacienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Paciente> ListarTodos()
        {
            var lista = new List<Paciente>();

            var comando = _conexao.CreateCommand("SELECT * FROM paciente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var paciente = new Paciente();
                paciente.Id = leitor.GetInt32("id_pac");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Endereco = DAOHelper.GetString(leitor, "endereco_pac");
                paciente.Nascimento = leitor.GetDateTime("nascimento_pac");

                lista.Add(paciente);
            }

            return lista;
        }

        public void Inserir(Paciente paciente)
        {
            try
            {
                var sql = @"INSERT INTO paciente  (nome_pac, telefone_pac, email_pac, endereco_pac, nascimento_pac) 
             VALUES (@nome, @telefone, @email, @endereco, @nascimento);";

                var cmd = _conexao.CreateCommand(sql);

                cmd.Parameters.AddWithValue("@nome", paciente.Nome);
                cmd.Parameters.AddWithValue("@telefone", paciente.Telefone);
                cmd.Parameters.AddWithValue("@email", paciente.Email);
                cmd.Parameters.AddWithValue("@endereco", paciente.Endereco);
                cmd.Parameters.AddWithValue("@nascimento", paciente.Nascimento);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
        }

        public Paciente? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM paciente WHERE id_pac = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var paciente = new Paciente();
                paciente.Id = leitor.GetInt32("id_pac");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Email = DAOHelper.GetString(leitor, "email_pac");
                paciente.Endereco = DAOHelper.GetString(leitor, "endereco_pac");
                paciente.Nascimento = leitor.GetDateTime("nascimento_pac");

                return paciente;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Paciente paciente)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE paciente SET nome_pac = @nome, telefone_pac = @telefone, " +
                    "email_pac = @email, endereco_pac = @endereco, nascimento_pac = @nascimento " +
                    "WHERE id_pac = @id;");

                comando.Parameters.AddWithValue("@nome", paciente.Nome);
                comando.Parameters.AddWithValue("@telefone", paciente.Telefone);
                comando.Parameters.AddWithValue("@email", paciente.Email);
                comando.Parameters.AddWithValue("@endereco", paciente.Endereco);
                comando.Parameters.AddWithValue("@nascimento", paciente.Nascimento);
                comando.Parameters.AddWithValue("@id", paciente.Id);

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
                    "DELETE FROM paciente WHERE id_pac = @id;");

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

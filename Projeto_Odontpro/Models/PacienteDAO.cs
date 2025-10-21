<<<<<<< HEAD
﻿using Projeto_Odontpro.Configs;
=======
﻿
using Projeto_Odontpro.Configs;
>>>>>>> 55a8fe03f9dbd34e0eed966cdd06449e5fb331c6

namespace Projeto_Odontpro.Models
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

            var comando = _conexao.CreateCommand("SELECT * FROM Paciente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var paciente = new Paciente();
                paciente.Id = leitor.GetInt32("id_pac");
                paciente.Nome = DAOHelper.GetString(leitor, "nome_pac");
                paciente.Sexo = DAOHelper.GetString(leitor, "sexo_pac");
                paciente.Telefone = DAOHelper.GetString(leitor, "telefone_pac");
                paciente.Nascimento = leitor.GetDateTime("data_nascimento_pac");
                paciente.Estado = DAOHelper.GetString(leitor, "estado_pac");
                paciente.Observacoes = DAOHelper.GetString(leitor, "observacoes_pac");

                lista.Add(paciente);
            }

            return lista;
        }

        public void Inserir(Paciente paciente)
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
    }
}

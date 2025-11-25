using Projeto_Odontpro.Configs;


namespace Projeto_Odontpro.Models.Atendimento
{
    public class AtendimentoDAO
    {    
        
            private readonly Conexao _conexao;

            public AtendimentoDAO(Conexao conexao)
            {
                _conexao = conexao;
            }

            public List<Atendimento> ListarTodos()
            {
                var lista = new List<Atendimento>();

                var comando = _conexao.CreateCommand("SELECT * FROM Atendimento;");
                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    //esse daohelper nao é obrigatorio, ele serve apenas para padronizar e fezer tratamento de erro, é bom usalo mas tem que saber como usar
                    //so o Get(tipo) ja serve
                    var aviso = new Atendimento();
                      aviso.Id = leitor.GetInt32("id_men");
                      aviso.Texto = DAOHelper.GetString(leitor, "texto_men");
                      aviso.EnviarParaTodos = leitor.GetString("enviar_para_todos_men");
                      aviso.DataEnvio = leitor.GetDateTime("data_envio_men");
               
                    lista.Add(aviso);
                }

                return lista;
            }

            public void Inserir(Atendimento atendimento)
            {
                try
                {
                    var sql = @"INSERT INTO Atendimento (texto_men, enviar_para_todos_men, data_envio_men) VALUES (@texto, @EnviarParaTodos, @DataEnvio );";

                    var cmd = _conexao.CreateCommand(sql);


                    cmd.Parameters.AddWithValue("@texto", atendimento.Texto);
                    cmd.Parameters.AddWithValue("@EnviarParaTodos", atendimento.EnviarParaTodos);
                    cmd.Parameters.AddWithValue("@DataEnvio", atendimento.DataEnvio);
           

                    cmd.ExecuteNonQuery();


                }
                catch
                {
                    return;
                }
            }

            public Atendimento? BuscarPorId(int id)
            {
                var comando = _conexao.CreateCommand(
                    "SELECT * FROM Atendimento WHERE id_men = @id;");
                comando.Parameters.AddWithValue("@id", id);

                var leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    var aviso = new Atendimento();
                     aviso.Id = leitor.GetInt32("id_men");
                     aviso.Texto = DAOHelper.GetString(leitor, "texto_men");
                     aviso.EnviarParaTodos = leitor.GetString("enviar_para_todos_men");
                     aviso.DataEnvio = leitor.GetDateTime("data_envio_men");

                return aviso;
                }
                else
                {
                    return null;
                }
            }

            public void Atualizar(Atendimento atendimento)
            {
                try
                {
                       var comand = _conexao.CreateCommand(
                        "UPDATE Atendimento SET texto_men = @texto, enviar_para_todos_men = @enviarParaTodos, data_envio_men = @dataEnvio " +
                        "WHERE id_men = @id;");

                         comand.Parameters.AddWithValue("@texto", atendimento.Texto);
                         comand.Parameters.AddWithValue("@enviarParaTodos", atendimento.EnviarParaTodos);
                         comand.Parameters.AddWithValue("@dataEnvio", atendimento.DataEnvio);
                         comand.Parameters.AddWithValue("@id", atendimento.Id);

                comand.ExecuteNonQuery();
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
                        "DELETE FROM Atendimento WHERE id_men = @id;");

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

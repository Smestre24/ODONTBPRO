using Projeto_Odontpro.Configs;
using Projeto_Odontpro.Models.Financeiro;

namespace Projeto_Odontpro.Models.Financeiro
{
    public class FinanceiroDAO
    {
        private readonly Conexao _conexao;

        public FinanceiroDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Transacao> ListarTodos()
        {
            List<Transacao> lista = new List<Transacao>();
            try
            {
                var comando = _conexao.CreateCommand("SELECT * FROM financeiro;");
                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    lista.Add(new Transacao
                    {
                        Id = leitor.GetInt32("id_fin"),
                        Data = leitor.GetDateTime("data_fin"),
                        Descricao = leitor.GetString("descricao_fin"),
                        Nome_Pagador = leitor.GetString("nome_pagador_fin"),
                        Tipo = leitor.GetString("tipo_fin"),
                        Valor = leitor.GetDecimal("valor_fin"),
                    });
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return lista;
            }



            return lista;
        }
        public void AdicionarTransacao(Transacao t)
        {
            try
            {
                // comando parametrizado para evitar SQL injection / problemas de formatação
                var sql = @"INSERT INTO financeiro (data_fin, nome_pagador_fin, descricao_fin, tipo_fin, valor_fin)
                            VALUES (@_data, @_nome, @_descricao, @_tipo, @_valor);";

                var cmd = _conexao.CreateCommand(sql);
                // Ajuste do parâmetro para o tipo aceito pelo CreateCommand (depende da implementação)
                cmd.Parameters.AddWithValue("@_data", t.Data);
                cmd.Parameters.AddWithValue("@_nome", t.Nome_Pagador ?? string.Empty);
                cmd.Parameters.AddWithValue("@_descricao", t.Descricao ?? string.Empty);
                cmd.Parameters.AddWithValue("@_tipo", t.Tipo ?? "gasto");
                cmd.Parameters.AddWithValue("@_valor", t.Valor);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir transação: " + ex.Message);
                throw;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                // logica basica de delete + verificação
                const string sql = @"DELETE FROM financeiro WHERE (id_fin = @_id);";

                using var cmd = _conexao.CreateCommand(sql);                
                cmd.Parameters.AddWithValue("@_id", id);

                //linhasAfetadas é usado para verificar se relamente alguma coisa foi afetado
                int linhasAfetadas = cmd.ExecuteNonQuery();

                //se nenhuma linha for afetada(nada ter sido excluido) ele retorna falso, caso contrario retorna true
                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // log opcional
                return false;
            }
        }

        //editar basico
        public bool Editar(Transacao transacao)
        {
            try
            {
                const string sql = @"
            UPDATE financeiro
            SET 
                nome_pagador_fin = @_nome,
                descricao_fin = @_descricao,
                valor_fin = @_valor,
                data_fin = @_data,
                tipo_fin = @_tipo
            WHERE (id_fin = @_id);
        ";

                using var cmd = _conexao.CreateCommand(sql);
               

                cmd.Parameters.AddWithValue("@_id", transacao.Id);
                cmd.Parameters.AddWithValue("@_nome", transacao.Nome_Pagador);
                cmd.Parameters.AddWithValue("@_descricao", transacao.Descricao);
                cmd.Parameters.AddWithValue("@_valor", transacao.Valor);
                cmd.Parameters.AddWithValue("@_data", transacao.Data);
                cmd.Parameters.AddWithValue("@_tipo", transacao.Tipo);

                int linhas = cmd.ExecuteNonQuery();

                return linhas > 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao editar: " + ex.Message);
                return false;
            }
        }

        //A logica do buscar por id é assim: se nao encontrar(o q é muito dificil), ele retorna nulo e nao mostra nada na tela
        //se encontrar mostra os dados nomalmente
        public Transacao? BuscarPorId(int id)
        {
            try
            {
                const string sql = @"
            SELECT 
                id_fin,
                nome_pagador_fin,
                descricao_fin,
                valor_fin,
                data_fin,
                tipo_fin
            FROM financeiro
            WHERE (id_fin = @_id);
        ";

                using var cmd = _conexao.CreateCommand(sql);
                cmd.Parameters.AddWithValue("@_id", id);

                using var leitor = cmd.ExecuteReader();

                if (leitor.Read())
                {
                    return new Transacao
                    {
                        Id = leitor.GetInt32("id_fin"),
                        Nome_Pagador = leitor.GetString("nome_pagador_fin"),
                        Descricao = leitor.GetString("descricao_fin"),
                        Valor = leitor.GetDecimal("valor_fin"),
                        Data = leitor.GetDateTime("data_fin"),
                        Tipo = leitor.GetString("tipo_fin")
                    };
                }

                return null; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar por ID: " + ex.Message);
                return null;
            }
        }

    }


}

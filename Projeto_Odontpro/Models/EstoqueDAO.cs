using Projeto_Odontpro.Configs;
using Projeto_Odontpro.Models;

namespace AppWeb.Models
{
    public class EstoqueDAO
    {
        private readonly Conexao _conexao;

        public EstoqueDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Estoque> ListarTodos()
        {
            var lista = new List<Estoque>();

            var comando = _conexao.CreateCommand("SELECT * FROM estoque;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var estoque = new Estoque();
                estoque.Id = leitor.GetInt32("id_est");
                estoque.Nome = DAOHelper.GetString(leitor, "nome_est");
                estoque.Quantidade = leitor.GetInt32("quantidade_est");
                estoque.FormaPagamento = DAOHelper.GetString(leitor, "forma_pagamento_est");
                estoque.Marca = DAOHelper.GetString(leitor, "marca_est");
                estoque.Valor = leitor.GetDecimal("preco_est");
                estoque.Descricao = DAOHelper.GetString(leitor, "descricao_est");

                lista.Add(estoque);
            }

            return lista;
        }

        public void Inserir(Estoque estoque)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "INSERT INTO estoque (nome_est, quantidade_est, forma_pagamento_est, marca_est, preco_est, descricao_est) " +
                "VALUES (@nome, @quantidade, @formapagamento, @marca, @preco, @descricao);");

                comando.Parameters.AddWithValue("@nome", estoque.Nome);
                comando.Parameters.AddWithValue("@quantidade", estoque.Quantidade);
                comando.Parameters.AddWithValue("@formapagamento", estoque.FormaPagamento);
                comando.Parameters.AddWithValue("@marca", estoque.Marca);
                comando.Parameters.AddWithValue("@preco", estoque.Valor);
                comando.Parameters.AddWithValue("@descricao", estoque.Descricao);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

        }

        public Estoque? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM estoque WHERE id_est = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var estoque = new Estoque();
                estoque.Id = leitor.GetInt32("id_est");
                estoque.Nome = DAOHelper.GetString(leitor, "nome_est");
                estoque.Quantidade = leitor.GetInt32("quantidade_est");
                estoque.FormaPagamento = DAOHelper.GetString(leitor, "forma_pagamento_est");
                estoque.Marca = DAOHelper.GetString(leitor, "marca_est");
                estoque.Valor = leitor.GetDecimal("preco_est");
                estoque.Descricao = DAOHelper.GetString(leitor, "descricao_est");

                return estoque;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Estoque estoque)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE estoque SET nome_est = @_nome, quantidade_est = @_quantidade, forma_pagamento_est = @_formapamento, marca_est = @_marca, preco_est = @_preco " +
                "descricao_est = @_descricao WHERE id_est = @_id;");

                comando.Parameters.AddWithValue("@nome", estoque.Nome);
                comando.Parameters.AddWithValue("@quantidade", estoque.Quantidade);
                comando.Parameters.AddWithValue("@formapagamento", estoque.FormaPagamento);
                comando.Parameters.AddWithValue("@marca", estoque.Marca);
                comando.Parameters.AddWithValue("@preco", estoque.Valor);
                comando.Parameters.AddWithValue("@descricao", estoque.Descricao);

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
                "DELETE FROM estoque WHERE id_est = @id;");

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
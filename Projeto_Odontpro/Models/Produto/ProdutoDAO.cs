using Projeto_Odontpro.Configs;

namespace Projeto_Odontpro.Models.Produto
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;

        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                //esse daohelper nao é obrigatorio, ele serve apenas para padronizar e fezer tratamento de erro, é bom usalo mas tem que saber como usar
                //so o Get(tipo) ja serve
                var estoque = new Produto();
                estoque.Id = leitor.GetInt32("id_pro");
                estoque.Nome = DAOHelper.GetString(leitor, "nome_pro");
                estoque.Quantidade = leitor.GetInt32("quantidade_pro");            
                estoque.Preco = leitor.GetDecimal("preco_pro");
                estoque.Descricao = DAOHelper.GetString(leitor, "descricao_pro");

                lista.Add(estoque);
            }

            return lista;
        }

        public void Inserir(Produto produto)
        {
            try
            {
                var sql = @"INSERT INTO produto (nome_pro, descricao_pro, quantidade_pro, preco_pro) VALUES (@nome, @descricao, @quantidade, @preco);";

                var cmd = _conexao.CreateCommand(sql);


                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("@preco", produto.Preco);

                cmd.ExecuteNonQuery();

  
            }
            catch
            {
                return;
            }
        }

        public Produto? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM produto WHERE id_pro = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = DAOHelper.GetString(leitor, "nome_pro");
                produto.Descricao = DAOHelper.GetString(leitor, "descricao_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Preco = leitor.GetDecimal("preco_pro");

                return produto;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE produto SET nome_pro = @nome, descricao_pro = @descricao, quantidade_pro = @quantidade, preco_pro = @preco " +
                    "WHERE id_pro = @id;");

                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@preco", produto.Preco);
                comando.Parameters.AddWithValue("@id", produto.Id);

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
                    "DELETE FROM produto WHERE id_pro = @id;");

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
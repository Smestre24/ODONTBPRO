using Projeto_Odontpro.Configs;
using System;
using System.Collections.Generic;

namespace Projeto_Odontpro.Models
{
    public class ContasAPagarDAO
    {
        private readonly Conexao _conexao;

        public ContasAPagarDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<ContasAPagar> ListarTodos()
        {
            var lista = new List<ContasAPagar>();
            var comando = _conexao.CreateCommand("SELECT * FROM contasaApagar;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var conta = new ContasAPagar();
                conta.Nome = DAOHelper.GetString(leitor, "nomecp_cont");
                conta.Descricao = DAOHelper.GetString(leitor, "descricaocp_est");
                conta.Valor = leitor.GetDecimal("valorcp_est");
                lista.Add(conta);
            }

            return lista;
        }

        public void Inserir(ContasAPagar conta)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "INSERT INTO contasaApagar (nomecp_cont, descricaocp_est, valorcp_est) VALUES (@nome, @descricao, @valor);"
                );

                comando.Parameters.AddWithValue("@nome", conta.Nome);
                comando.Parameters.AddWithValue("@descricao", conta.Descricao);
                comando.Parameters.AddWithValue("@valor", conta.Valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

   
}

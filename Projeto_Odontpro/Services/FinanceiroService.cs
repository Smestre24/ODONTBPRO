
using System.Collections.Generic;
using System.Linq;

namespace Projeto_Odontpro.Models
{
    public class FinanceiroService
    {
        private readonly ContasAPagarDAO _dao;

        public FinanceiroService(ContasAPagarDAO dao)
        {
            _dao = dao;
        }

      
        public List<ContasAPagar> Listar() => _dao.ListarTodos();

       
        public void Adicionar(ContasAPagar conta)
        {
            _dao.Inserir(conta);
        }

        public decimal TotalGastos() => _dao.ListarTodos().Sum(c => c.Valor);

     
        public decimal TotalGanhos() => 0;

        public decimal SaldoAtual() => TotalGanhos() - TotalGastos();
    }
}

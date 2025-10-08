using System.Collections.Generic;
using System.Linq;

namespace Projeto_Odontpro.Models
{
    public class FinanceiroService
    {
        private readonly List<Transacao> _transacoes = new();

        public void Adicionar(Transacao t)
        {
            _transacoes.Add(t);
        }

        public IEnumerable<Transacao> Listar() => _transacoes;

        public decimal TotalGanhos() => _transacoes.Where(t => t.EhGanho).Sum(t => t.Valor);
        public decimal TotalGastos() => _transacoes.Where(t => !t.EhGanho).Sum(t => t.Valor);
        public decimal SaldoAtual() => TotalGanhos() - TotalGastos();
    }
}
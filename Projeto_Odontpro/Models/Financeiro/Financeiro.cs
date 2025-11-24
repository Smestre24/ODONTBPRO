namespace Projeto_Odontpro.Models.Financeiro
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Nome_Pagador { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } // ganho / gasto
        public DateTime Data { get; set; }
    }
}
namespace Projeto_Odontpro.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Quantidade { get; set; }
        public string? FormaPagamento { get; set; }
        public string? Marca { get; set; }
        public decimal Valor { get; set; }
        public string? Descricao { get; set; }
    }
}

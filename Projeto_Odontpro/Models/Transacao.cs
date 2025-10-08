namespace Projeto_Odontpro.Models
{
    public class Transacao
    {
        public DateTime Data { get; set; } = DateTime.Now;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
        public bool EhGanho { get; set; }
    }
}
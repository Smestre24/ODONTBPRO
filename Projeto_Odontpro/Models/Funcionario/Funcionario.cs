using Org.BouncyCastle.Operators;

namespace Projeto_Odontpro.Models.Funcionario
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
        public DateTime Nascimento { get; set; }
        public string Endereco { get; set; }
        public decimal Salario { get; set; }
        public string Observacoes { get; set; }
    }
}
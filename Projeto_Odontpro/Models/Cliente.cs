using Mysqlx.Sql;

namespace Projeto_Odontpro.Models
{
    public class Cliente
    {       
            public int Id { get; set; }
            public string Nome { get; set; } 
            public string Email { get; set; }
           public string Sexo { get; set; }
            public  string Telefone { get; set; }
            public string Endereco { get; set; }
            public string Nascimento { get; set; }
            public string Estado { get; set; }
            public string Observaçoes  { get; set; }
        
    }
}

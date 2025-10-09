namespace Projeto_Odontpro.Models
{
    public class Cliente
    {       
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public bool Ativo { get; set; } = true;
            public bool Selecionado { get; set; } = false; 
        
    }
}

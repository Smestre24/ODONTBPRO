namespace Projeto_Odontpro.Models.Atendimento
{
    public class Atendimento
    {    
            public int Id { get; set; }
            public string? Texto { get; set; }
            public string? EnviarParaTodos { get; set; }
            public DateTime DataEnvio { get; set; }
        
    }
}

namespace Projeto_Odontpro.Models
{
    public class PacienteService
    {
        private List<Paciente> pacientes = new()
    {
        new Paciente { Id = 1, Nome = "João Silva", CPF = "123.456.789-00", Telefone = "(69) 99999-1111", Cidade = "Ji-Paraná" },
        new Paciente { Id = 2, Nome = "Maria Souza", CPF = "987.654.321-00", Telefone = "(69) 98888-2222", Cidade = "Porto Velho" }
    };

        public Task<List<Paciente>> GetPacientesAsync()
        {
            return Task.FromResult(pacientes);
        }
    }
}

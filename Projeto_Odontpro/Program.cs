using Projeto_Odontpro.Components;
using Projeto_Odontpro.Configs;
using Projeto_Odontpro.Models.Financeiro;
using Projeto_Odontpro.Models.Funcionario;
using Projeto_Odontpro.Models.Produto;
using Projeto_Odontpro.Models.Paciente;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<Conexao>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// adicione as classes terminadas por DAO aqui
builder.Services.AddSingleton<FuncionarioDAO>();
builder.Services.AddSingleton<FinanceiroDAO>();
builder.Services.AddSingleton<ProdutoDAO>();
builder.Services.AddSingleton<PacienteDAO>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();





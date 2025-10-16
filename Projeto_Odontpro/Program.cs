using Projeto_Odontpro.Components;
using Projeto_Odontpro.Models;
using Projeto_Odontpro.Configs;
using Projeto_Odontpro.Services;
using MySql.Data;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<Conexao>();
builder.Services.AddSingleton<ContasAPagarDAO>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddSingleton<PacienteService>();
builder.Services.AddSingleton<FinanceiroService>();
builder.Services.AddSingleton<FuncionarioService>();



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





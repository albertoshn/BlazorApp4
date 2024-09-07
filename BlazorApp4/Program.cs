using BlazorApp4.Components;
using BlazorApp4.Models;
using BlazorApp4.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CrudcursoContext>( opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql"));
});

string cadenaConexion = builder.Configuration.GetConnectionString("conexionSql");


builder.Services.AddScoped( provider => new sDepartamento(cadenaConexion));
builder.Services.AddScoped(provider => new sUsuario(cadenaConexion));


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

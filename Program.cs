using LanceCerto.WebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registro do DbContext com a string de conexão
builder.Services.AddDbContext<LanceCertoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middlewares padrão
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Imovel/Error"); // Alterado para refletir o controller atual, se necessário
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Rota padrão atualizada para ImovelController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Imovel}/{action=Index}/{id?}");

app.Run();
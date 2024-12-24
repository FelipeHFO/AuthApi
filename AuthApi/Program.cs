using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar reposit�rios
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Registrar servi�os
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Adicionar controllers
builder.Services.AddControllers();  // Adicionar o servi�o para os controladores

var app = builder.Build();

// Configura��o das rotas para o resto do aplicativo
app.MapControllers();  // Mapeando os controladores

// Executar a aplica��o
app.Run();

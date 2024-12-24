using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Registrar serviços
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// Adicionar controllers
builder.Services.AddControllers();  // Adicionar o serviço para os controladores

var app = builder.Build();

// Configuração das rotas para o resto do aplicativo
app.MapControllers();  // Mapeando os controladores

// Executar a aplicação
app.Run();

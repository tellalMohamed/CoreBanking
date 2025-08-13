using CoreBanking.Domain.Repositories;
using CoreBanking.Infrastructure;
using CoreBanking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CoreBanking.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Enregistrer le DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Enregistrer les repositories
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICompteRepository, CompteRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// 3. Ajouter les services applicatifs
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CompteService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

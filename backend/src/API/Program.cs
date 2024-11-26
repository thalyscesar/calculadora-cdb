

using CalculadoraCDB.Domain.Services;
using CalculadoraCDB.Domain.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICDBService, CDBService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculadora CDB v1");
    options.RoutePrefix = string.Empty; // Para abrir o Swagger na raiz da aplicação
});

app.MapGet("/", () => "Bem-vindo à API com Swagger!");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MinhaPolicy");

app.MapControllers();

app.Run();




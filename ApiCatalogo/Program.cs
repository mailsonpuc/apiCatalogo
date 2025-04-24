using System.Text.Json.Serialization;
using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllers()
.AddJsonOptions(opt =>
opt.JsonSerializerOptions
.ReferenceHandler = ReferenceHandler.IgnoreCycles);



// Configura o Swagger/OpenAPI corretamente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Isso já é o suficiente, o AddOpenApi() não é necessário

// Configura o DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opt.RoutePrefix = string.Empty; // Swagger UI na raiz do app
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

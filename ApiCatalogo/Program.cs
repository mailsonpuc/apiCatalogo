using System.Text.Json.Serialization;
using ApiCatalogo.Context;
using ApiCatalogo.DTOs.Mappings;
using ApiCatalogo.Filters;
using ApiCatalogo.Logging;
using ApiCatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Adiciona os serviços ao containe
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});






// Configura o Swagger/OpenAPI corretamente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Isso já é o suficiente, o AddOpenApi() não é necessário

// Configura o DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



//usando o filtro
builder.Services.AddScoped<ApiLoggingFilter>();


//usando repository
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

//uniofwork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//usando repository Generico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//usando automapper
builder.Services.AddAutoMapper(typeof(ProdutoDTOMappingProfile));



//usando loggin e gravando  e um txt
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));



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

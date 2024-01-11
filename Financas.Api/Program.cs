using Financas.Api.Extensions;
using Financas.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//colocar os endpoints em caixa baixa
builder.Services.AddRouting(map => map.LowercaseUrls = true);

//extensions
builder.Services.AddSwaggerConfig();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddMongoDB(builder.Configuration);
builder.Services.AddCorsConfig();

var app = builder.Build(); //deploy

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerConfig();
app.UseCorsConfig();
app.UseAuthorization();
app.MapControllers();

app.Run(); //executar o projeto

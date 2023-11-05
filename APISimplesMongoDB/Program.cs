using APISimplesMongoDB.Models;
using APISimplesMongoDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container:

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção da ConnectionString do appsettings.json
builder.Services.Configure<ProdutoDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase")); 
builder.Services.AddSingleton<ProdutoServices>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using OP.Brander.Application;
using OP.Brander.Persistence;
using OP.Brander.Shared;
using OP.Brander.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(configuration);
builder.Services.AddPersistenceInfraestructure(configuration);
builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.UseErrorHandleMiddleware();

app.MapControllers();

app.Run();

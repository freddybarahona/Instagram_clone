using InstagramClone.Application.Interfaces.Services;
using InstagramClone.Application.Services;
using InstagramClone.Domain.Database.SqlServer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// este builder es una funcionalidad que debe ponerse antes de construir porque sino esta construyendo y luego cambiando la config inicial DARA ERROR
builder.Services.AddScoped<IUserService, UserService>();

//Database
builder.Services.AddSqlServer<InstagramCloneContext>(builder.Configuration.GetConnectionString("Database"));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

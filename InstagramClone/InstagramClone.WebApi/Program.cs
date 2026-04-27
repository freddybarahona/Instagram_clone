using InstagramClone.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
//-------------------------------------------------
//esto conecta a la extension que tiene todo lo que necesita la app para funcionar y conectarse
builder.Services.AddCore(builder.Configuration);
//-------------------------------------------------

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//-------------------------------------------------
//esta extension anade las Redirections, authorization y mapcontrollers
app.AddFinals(app);
//-------------------------------------------------

app.Run();
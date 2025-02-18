

using NSE.Catalogo.API.Configuration;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.RegisterServices();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


app.UseApiConfiguration(app.Environment);


app.UseSwagger();

app.Run();



using NSE.Catalogo.API.Configuration;
using NSE.WebAPI.Core.Identity;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddAuthConfiguration(builder.Configuration);

builder.Services.RegisterServices();




builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


app.UseApiConfiguration(app.Environment);


app.UseSwagger();

app.Run();

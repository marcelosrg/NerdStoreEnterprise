using Microsoft.OpenApi.Models;

namespace NSE.Catalogo.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NerdStore Enterprise Identity API",
                    Description = "Esta API faz parte do curso ASP.NET Core Enterprise Application.",
                    Contact = new OpenApiContact { Name = "Marcelo Henrique", Email = "marcelodotnet@gmail.com" },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("http://opensource.org/licenses/MIT") }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Add you JWT token: Bearer {token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });


            });


            services.AddSwaggerGen();
            return services;
        }


        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}

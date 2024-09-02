using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;
using System.Runtime.CompilerServices;

namespace Restaurants.API.Extension;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        // Add services to the DI Container
        builder.Services.AddAuthentication();


        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {

                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Description = "Authorization header using the Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bearerAuth"
                        }
                    },
                    //new string[] {}
                    []
                }
            });
        });

        builder.Services.AddEndpointsApiExplorer();


        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
            configuration
                .ReadFrom.Configuration(context.Configuration)
        );


    }
}

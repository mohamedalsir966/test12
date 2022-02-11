using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alone.Registrations
{
    public static class SwaggerRegistrations
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "0.1",
                    Title = "Covid Certificate API",
                    Description = "CovidCertificate",
                });
            });

            return services;
        }
    }
}

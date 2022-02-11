using alone.Domin;
using alone.Domin.Repositories;
using alone.Domin.Servises;
using alone.Persistence.Reositories;
using alone.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using alone.Validators;
using FluentValidation;
using alone.Persistence.Contexts;
using alone.Registrations;
using alone.Middlewares;
using alone.Cacheding;

namespace alone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();
            services.AddValidatorsFromAssembly(GetType().Assembly);
            // services.AddControllers();
            //services.AddDbContext<AppDbContext>(options => {
            //    options.UseInMemoryDatabase("supermarket-api-in-memory");
            //});
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SupermarketConnecionString")));
            services.AddScoped<ICategoryRepositories, CategoryRepository>();
            services.AddScoped<IcategoryServices, CatogryServices>();
            services.AddScoped<IproductRepositories, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDistributedRedisCache(o =>
            {
                o.Configuration = Configuration.GetValue<string>("Redis:ConnectionString");
            });

            services.AddScoped<CacheService>();
            services.AddAutoMapper(GetType().Assembly, typeof(Mapping.ModelToResourceProfile).Assembly);
            services.AddSwaggerGen();
            
            //services.AddExceptionHandler();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });
        }
    }
}

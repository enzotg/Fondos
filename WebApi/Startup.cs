using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;
using MediatR;
using System.Reflection;
using Domain.Entities;

namespace WebApi
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
            services.AddDbContext<FondosContext>(options => options.UseSqlite("data source=fondoster.db"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            var assApp = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(Assembly.GetExecutingAssembly(), assApp);

            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<IMovimientoRepository, MovimientoRepository>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IGenericRepositoryAsync<Persona>, GenericRepositoryAsync<Persona>>();
            services.AddTransient<IGenericRepositoryAsync<Operacion>, GenericRepositoryAsync<Operacion>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

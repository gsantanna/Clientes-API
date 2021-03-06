    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Application.Interfaces;
using Project.Application.Services;
using Project.CrossCutting.IoC;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using Project.Domain.Services;
using Project.Infra.Context;
using Project.Infra.Repositories;
using Project_Presentation.Configurations;

namespace Project_Presentation
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
            services.AddControllers();

            SwaggerSetup.AddSwaggerSetup(services);

            DependencyInjection.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}

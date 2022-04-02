using FluentValidation.AspNetCore;
using GYS.SOL.Contracto;
using GYS.SOL.Implementacion;
using GYS.SOL.Servicio.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYS.SOL.Servicio
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
            //--------------------------------------------------------------------------------
            //-- Servicios
            //--------------------------------------------------------------------------------
            services.AddTransient<IClienteServicio, ClienteServicio>();
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            })
         .AddFluentValidation(options =>
         {
             options.RegisterValidatorsFromAssemblyContaining<Startup>();
         });
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
        }
    }
}

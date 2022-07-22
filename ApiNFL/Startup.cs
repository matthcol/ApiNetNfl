using ApiNFL.Mapper;
using ApiNFL.Mapper.Impl;
using ApiNFL.Repository;
using ApiNFL.Repository.Impl;
using ApiNFL.Service;
using ApiNFL.Service.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNFL
{
    public class Startup
    {

        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
                opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>()
            );
            services.AddSwaggerGen();
            services.AddDbContext<NFLDbContext>(opt => 
                // In Memory:
                //opt.UseInMemoryDatabase("dbnfl")
                // MariaDb:
                opt.UseMySql(_config.GetConnectionString("dbnfl"))
                );
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<INflMapper, NflMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Rest NFL"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
           /*     endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
                endpoints.MapControllers();
            });
        }
    }
}

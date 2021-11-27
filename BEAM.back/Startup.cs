using BEAM.back.Repositories;
using BEAM.back.Services;
using BEAM.back.Utils;
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

namespace BEAM.back
{
    public class Startup
    {
        private const string LOCAL_ORIGINS = "localOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IScooterRepository, ScooterRepository>();
            services.AddScoped<IScooterService, ScooterService>();
            services.AddScoped<IDistanceProvider, DistanceProvider>();
            services.AddScoped<ILocationProvider, LocationProvider>();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: LOCAL_ORIGINS, builder => {
                    builder.WithOrigins("http://localhost:8080");
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UsePathBase(Environment.GetEnvironmentVariable("SUBPATH"));

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(LOCAL_ORIGINS);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"v1/swagger.json", "BEAM API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

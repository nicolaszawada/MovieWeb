using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieWeb.Api.Dto;
using MovieWeb.Api.Profiles;
using MovieWeb.Database;
using MovieWeb.Services;
using MovieWeb.Services.Impl;
using System;
using System.Diagnostics;
using System.IO;

namespace MovieWeb.Api
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
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieWeb.Api", Version = "v1" });
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "MovieWeb.Api.xml"));
            });

            services.AddTransient<IActorService, ActorService>();

            services.AddAutoMapper(typeof(ActorProfile));

            services.Configure<DeveloperDto>(Configuration.GetSection("Developer"));

            services.AddDbContext<MovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                var sw = Stopwatch.StartNew();
                await next();
                Console.WriteLine("Request took:" + sw.ElapsedMilliseconds);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieWeb.Api v1"));
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

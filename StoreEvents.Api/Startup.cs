using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StoreEvents.Api.Setup;

namespace StoreEvents.Api
{
    public class Startup
    {
        private readonly string _enableCors = "MyCors";
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterServices(Configuration);

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApi Imagens",
                    Version = "v1",
                    Description = "Api para guardar e buscar imagens de diferentes tipos de recurso",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme dos Reis",
                        Url = new Uri("https://guibolt.github.io/")
                    },
                });

            });


            services.AddCors(opt =>
            {
                opt.AddPolicy(_enableCors, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build();
                }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiImagens");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(_enableCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

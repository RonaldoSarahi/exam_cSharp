using csharp_api.Data;
using csharp_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_api
{
    public class Startup
    {
        private readonly string cSharpCORSPolicy = "cSharpCORSPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Add the database 
            services.AddDbContext<ExamDbContext>();

            // Adding CORS policies
            services.AddCors(options => {
                options.AddPolicy(cSharpCORSPolicy,
                    builder => {
                        builder.WithOrigins(
                             "https://localhost:5001",
                            "https://localhost:5000",
                            "https://localhost:5002",
                            "http://localhost:5002",
                            "http://localhost:5000",
                            "https://localhost:44339",
                            "http://localhost:44339")

                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            // Add utility services
            services.AddHttpContextAccessor();

            // Singleton services
            
            // Scoped services
            services.TryAddScoped<IArticulosService, ArticulosService>();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(cSharpCORSPolicy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

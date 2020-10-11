using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BikeStore.Data.Models;
using BikeStore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BikeStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BikeStoresContext>(options => {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });

            services.GetBikeStoreRepositoryServices();
            services.GetBikeStoreCoreServices();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                        if (null != exceptionObject)
                        {
                            var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</b>{exceptionObject.Error.StackTrace}";
                            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                        }
                    });   
                });
            }

            app.UseRouting();

            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

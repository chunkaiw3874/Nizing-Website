using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nizing_2._0
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/darkthread")
                {                    
                    await context.Response.WriteAsync("ASP.NET Core Rocks!");
                    await next();
                }                    
                else
                {
                    await next();
                    await context.Response.WriteAsync(" Powered by ASP.NET Core");
                }
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/darkthread")
                {

                    await next();
                    await context.Response.WriteAsync("ASP.NET Core Rocks2!");
                }
                else
                {
                    await next();
                    await context.Response.WriteAsync(" Powered by ASP.NET Core2");
                }
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/darkthread", async context =>
                {
                    await context.Response.WriteAsync("Handled by UseEndpoints");
                });
            });


        }
    }
}

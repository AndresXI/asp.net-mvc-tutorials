using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace L03HandsOn
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

            app.UseRouting();

            // app.Use(async (c, n) => {
            //     if(c.Request.Path.StartsWithSegments("/short")) {
            //         await c.Response.WriteAsync("Short circuiting");
            //     } else {
            //         await c.Response.WriteAsync("Not short circuting, calling next()\n");
            //         await n();
            //     }
            // });

            // app.Run(async c => {
            //     await c.Response.WriteAsync("Run() has executed\n");
            // });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.Map("/Mapped", app => {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Mapped was executed");
                });
            });


            app.Run(async c => {
                await c.Response.WriteAsync("Run() has executed\n");
            });

        }
    }
}

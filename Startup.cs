using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia
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

            // middleware that will take a URL and try to map it to
            // our root folder (special folder that separates static content)
            // This will redirect the user to the wwwroot folder, specifically
            // the index.html file if it exists
            app.UseFileServer();

            /* As shown here, we instead use the app.Use() method to execute against
             * requests. In this case, we grab the context representation and then
             * write to it using the Response.WriteAsync() method
             * Following that, we use the await next() statement to enable
             * additional methods to execute.
             * If a condition isn't satisfied, it's just skipped.
             */
            //app.Use(async (context, next) =>
            //{
            //    // we add a conditional to render the content when the given
            //    // path has /hello appened to it
            //    if (context.Request.Path.Value.StartsWith("/hello"))
            //    {
            //        await context.Response.WriteAsync("Hmm"); 
            //    }
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    // looks like the path is specific to the base URL used
            //    if (context.Request.Path.Value.StartsWith("/hello/yolo"))
            //    {
            //        await context.Response.WriteAsync(" Uh oh "); 
            //    }
            //    await next();
            //});

            // This is a function (middleware). It takes care of requests.
            // Since it has no logic and is the only piece of middleware, this
            // function wll execute for all requests.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Intriguing");
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World, Noah!");
            //    });
            //});
        }
    }
}

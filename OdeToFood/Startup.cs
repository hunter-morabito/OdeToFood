using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Way of telling ASP.NET core that you will only need one instance of this service for the entire application
            services.AddSingleton<IGreeter, Greeter>();

            // Any time someone needs a new service, create a new instance
            // services.AddTransient

            // Creates an instance for every request
            //services.AddScoped

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              // IGreeter is our custom interface, that needs to be configured using the configure services
                              // This is called Dependancy Injection
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {

            // How to get middleware:
            // app.Use

            //// How to write middleware:
            //app.Use(next =>
            //{
            //    // This returned  function is the actual middleware
            //    return async context =>
            //    {
            //        logger.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            // run this middleware
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request Handled");
            //        }
            //        else
            //        {
            //            // go to next piece of middleware
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };
            //});

            //// ORDER IS IMPORTANT
            //// Sample of middleware
            ////app.UseWelcomePage(new WelcomePageOptions
            //{
            //    // Create an options object that gets passed into the 'USE', and only run if the path is /wp
            //    Path = "/wp"
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // Dont normally see in normal asp.net applications
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }
    }
}

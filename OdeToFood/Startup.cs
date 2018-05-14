using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

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
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              // IGreeter is our custom interface, that needs to be configured using the configure services
                              // This is called Dependancy Injection
                              IGreeter greeter, ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            // Dont normally see in normal asp.net applications
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                // lets the browser interpret the text correctly
                context.Response.ContentType = "text/plain"; // Called a Mime Type
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/4

            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}");// the '?' means that the field is optional
        }
    }
}

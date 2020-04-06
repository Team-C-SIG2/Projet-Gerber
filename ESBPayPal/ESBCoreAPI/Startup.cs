using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ESBCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // SERVICES CONTAINER 
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // services.AddTransient<IAnInterface, ImplemenedInterface>
            // services.AddMvc(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //HB
            app.UseDeveloperExceptionPage();


            /*
            app.UseMvc(routes => {
                routes.MapRoute("secure", "secure", new { Controller = "Admin", Action = "GetOrders" });
                routes.MapRoute("admin", "{Controller=Admin}/{Action}/{id?}");
                routes.MapRoute("default", "api/{Controller=PizzaOrder}/{Action=GetOrders}/{id?}");
            }); 
             */


            /*
                         app.UseMvcWithDefaultRoute();
                        app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id}");  });            

            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

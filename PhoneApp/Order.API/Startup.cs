using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.Domain.ControllerWorkers;
using Order.Domain.DTO;

namespace Order.API
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
            services.AddMvc();

            ///Use DI with 3rd party library like Autofac or SimpleInjector, to resolve dependencies services by convention
            ///(TService, TImplementation) instead adding one line for each CW
            services.AddScoped<IOrderCW, OrderCW>();

            //Inject the Order.API config (only PhoneApi section) to Order.Domain, across PhoneApiConfiguration class
            services.Configure<PhoneApiConfiguration>(Configuration.GetSection("PhoneApiConfiguration"));
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

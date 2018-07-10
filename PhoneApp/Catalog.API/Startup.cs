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
using Microsoft.EntityFrameworkCore;
using Catalog.Infrastructure.Models;
using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Catalog.Infrastructure.UnitOfWork;
using Catalog.Domain.ControllerWorkers;

namespace Catalog.API
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
            services.AddEntityFrameworkSqlite()
                .AddDbContext<Context>(options =>
                {
                    var connString = Configuration.GetConnectionString("PhoneDatabase");
                    if(string.IsNullOrEmpty(connString)){
                        connString = "Data source = App_Data/phoneAppDB.db";
                    }
                    options.UseSqlite(connString);
                }, ServiceLifetime.Scoped);

            services.AddScoped<IRepository<Context>, Repository<Context>>();

            ///Use DI with 3rd party library like Autofac or SimpleInjector, to resolve dependencies services by convention
            ///(TService, TImplementation) instead adding one line for each CW
            services.AddScoped<IPhoneCW, PhoneControllerWorker>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var db = new Context())
            {
                db.Database.Migrate();
            }

            app.UseMvc();
        }
    }
}

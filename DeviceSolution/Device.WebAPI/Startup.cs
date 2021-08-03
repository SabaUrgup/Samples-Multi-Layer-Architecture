using Device.Business.Abstract;
using Device.Business.Concrete;
using Device.DataAccessLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Device.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device.WebAPI", Version = "v1" });
            });

            services.AddDbContext<DeviceDatabaseContext>();
            // her nesne için bir defa oluşturulur --> AddDbContext

            services.AddScoped<ITvService, TvService>();
            services.AddScoped<ITelService, TelService>();
            // İstek geldikçe nesne oluşturur --> AddScoped
            /// <summary>
 /// Understanding the life cycle of Dependency Injection (DI) is very important in ASP.Net Core applications. 
 /// As we know, Dependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies. 
 /// Most often, classes will declare their dependencies via their constructor, allowing them to follow the Explicit Dependencies Principle. This approach is known as "constructor injection".
 /// The lifetime of the service depends on when the dependency is instantiated and how long it lives.And lifetime depends on how we have registered those services.
        /// The below three methods define the lifetime of the services,
           //AddTransient
           //Transient lifetime services are created each time they are requested.
           //This lifetime works best for lightweight, stateless services.

           //AddScoped
           //Scoped lifetime services are created once per request.

           //AddSingleton
           //Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there)
           //and then every subsequent request will use the same instance.
            /// </summary>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device.WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

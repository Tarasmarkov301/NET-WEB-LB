using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospitals.Data.mock;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SaleOfNail.Controles;
using SaleOfNail.Data.Interfaces;
using SaleOfNail.Data.mock;
namespace SaleOfNail
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddTransient<iNail, mockNail>();
            services.AddTransient<iClient, mockClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

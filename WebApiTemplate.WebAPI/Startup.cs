using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Business;
using WebApiTemplate.Common.Common;
using WebApiTemplate.Common.IBusiness;
using WebApiTemplate.Common.IData;
using WebApiTemplate.Common.IModels;
using WebApiTemplate.Data;
using WebApiTemplate.WebAPI.Models;

namespace WebApiTemplate.WebAPI
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
            services.AddTransient<IApplicationSettings, ApplicationSettings>();

            services.AddTransient<IValueData, ValueData>();
            services.AddTransient<IValueBusiness, ValueBusiness>();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseMvc();
            
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Requested resource not found");
            });
        }
    }
}

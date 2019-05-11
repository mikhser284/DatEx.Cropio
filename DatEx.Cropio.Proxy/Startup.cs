using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DatEx.Cropio.Proxy.Model;
using DatEx.Cropio.Proxy.Services;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;

namespace DatEx.Cropio.Proxy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DbContextCropioProxy>(options => options.UseSqlServer("Data Source=ELMATEST2;Initial Catalog=ProxyDb.Cropio;Integrated Security=True"));
            services.AddOData();
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, BackgroundTaskService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(),"logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(b => { b.MapODataServiceRoute("odata", "odata", DbContextCropioProxy.GetEdmModel()); });
            app.UseResponseCompression();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DbContextCropioProxy>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }            
        }
    }
}

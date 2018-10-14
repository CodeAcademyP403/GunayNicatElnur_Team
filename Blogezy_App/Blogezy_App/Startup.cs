using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogezy_App.Data;
using Blogezy_App.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogezy_App
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogezyDbContext>(x => 
            {
                x.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddIdentity<UserApp, IdentityRole>()
                .AddEntityFrameworkStores<BlogezyDbContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(x=> {
                
                x.MapRoute(
                    name:"",
                    template:"{controller=Home}/{action=Index}/{id?}"
                );
                x.MapRoute(
                    name: "Admin",
                    template: "{area=exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

        }
    }
}

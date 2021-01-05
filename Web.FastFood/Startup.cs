using FastFood.Infrastucture.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFastFood.Services.Contracts;
using WebFastFood.Services.Repository;

namespace Web.FastFood
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            InitServices(services);
            services.AddControllersWithViews();
            services.AddHttpClient("FastFoodClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:64467");
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Authen/Login";
                    options.LogoutPath = "/Authen/SignOut";
                    options.Cookie.Name = "Authen.Coo";
                });


            //services.AddTransient<ICustomer, CustomerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Customer/Error");
            }
            app.UseCustomExceptionHandler();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authen}/{action=Login}/{id?}");
            });
        }

        public void InitServices(IServiceCollection services)
        {
            services.AddTransient<ICustomer, CustomerRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IStoreInvoicing, StoreInvoicingRepository>();
            services.AddTransient<IStoreInvoicingDetails, StoreInvoicingDetailsRepository>();
        }
    }
}

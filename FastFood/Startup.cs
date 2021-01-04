using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.DataLayer.DataAccess;
using FastFood.DataLayer.Services.Contracts;
using FastFood.DataLayer.Services.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FastFood
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            #region AddSwaggerGen
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My First Swagger"
                });
                swagger.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), @"bin\Debug\net5.0", "FastFood.xml"));
            });
            #endregion

            #region AddDbContext
            services.AddDbContext<FastFoodContext>(options =>
            {
                // services.AddDbContext<FastFoodContext>(options => { options.UseSqlServer
                //("Data Source=DESKTOP-9AQA9OL;Initial Catalog=FastFood;Integrated Security=False;User Id=sa;Password=123456"); });
                options.UseSqlServer(Configuration.GetConnectionString("FastFoodConnection"));

            });
            #endregion

            #region Add Controller / Services 
            services.AddControllersWithViews();
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllers();
            services.AddResponseCaching();

            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            InitServices(services);

            #region Jwt
            //Jwt
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:64467/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890 OurVerifyDotin"))
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                 {
                     builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .WithOrigins("http://localhost:64467")
                     //.WithOrigins("http://localhost:56240/")
                     .SetIsOriginAllowed(origin => true)
                     .AllowCredentials()
                     .Build();

                 });
            });

            #endregion
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger");
            });
            app.UseCors("EnableCors");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseResponseCaching();
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
                    pattern: "{controller=Customer}/{action=Index}/{id?}");
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void InitServices(IServiceCollection services)
        {
            services.AddTransient<ICustomer, CustomersRepository>();
            services.AddTransient<IStoreInvoicingDetails, StoreInvoicingDetailsRepository>();
            services.AddTransient<IStoreInvoicing, StoreInvoicingRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IProduct, ProductsRepository>();
            services.AddTransient<AutomapperConfig>();
            services.AddTransient<IAuthen, AuthenRepository>();
        }
    }
}

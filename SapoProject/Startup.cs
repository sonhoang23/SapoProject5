using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SapoProject.Areas.Admin.Models.Data;
using SapoProject.Areas.Admin.Repository.Interface;
using SapoProject.Areas.Admin.Repository.Repo;
using SapoProject.Areas.Customer.Repository.Interface;
using SapoProject.Areas.Customer.Repository.Repo;
using Westwind.AspNetCore.LiveReload;
namespace SapoProject
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
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddRazorPages();
            services.AddMvc()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/Components/Header/PartialView_Header.cshtml");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddLiveReload(config =>
             {
                 // optional - use config instead
                 //config.LiveReloadEnabled = true;
                 //config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
             });
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<SapoProjectDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SapoProjectDbContext")));
            services.AddMemoryCache();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISharedRepository, SharedRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISharedCustomerRepository, SharedCustomerRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Before any other output generating middleware handlers
            app.UseLiveReload();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Customer}/{action=index}/{id?}");
                // pattern: "{area=Admin}/{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}

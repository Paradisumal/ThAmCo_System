using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Model.Data;
using Customer.Web.Services.Basket;
using Customer.Web.Services.Customer;
using Customer.Web.Services.Order;
using Customer.Web.Services.Product;
using Customer.Web.Services.Review;
using CustomerWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerWebApplication
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        
        public Startup(IConfiguration configuration,
                       IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "";
                        options.Audience = "";
                    });*/

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*services.AddAuthentication("Cookies")
                    .AddCookie("Cookies");*/


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>();

            if(_env.IsDevelopment())
            {
                services.AddSingleton<ICustomerFacade, FakeCustomerFacade>();
                services.AddSingleton<IBasketFacade, FakeBasketFacade>();
                services.AddSingleton<IOrderFacade, FakeOrderFacade>();
                services.AddSingleton<IProductFacade, FakeProductFacade>();
                services.AddSingleton<IReviewFacade, FakeReviewFacade>();
            }
            else
            {
                services.AddHttpClient<ICustomerFacade, CustomerFacade>();
                services.AddHttpClient<IBasketFacade, BasketFacade>();
                services.AddHttpClient<IOrderFacade, OrderFacade>();
                services.AddHttpClient<IProductFacade, ProductFacade>();
                services.AddHttpClient<IReviewFacade, ReviewFacade>();
            }
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            /*app.UseAuthentication();*/

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

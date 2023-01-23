using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.Site.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site
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

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>();  //identity baglntý cml


            services.AddDbContext<Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConn")));  //baglantý clm


            services.AddAuthentication(
           CookieAuthenticationDefaults.AuthenticationScheme) //login-kimlik dogrulamasý için 
               .AddCookie(x =>
               {
                   x.LoginPath = "/Account/Login"; //giriþ yolu

               });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Account/Login";

            //});


            services.AddControllersWithViews();

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
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication(); //uygulamanýn identity ile kimlik doðrulamasý gerçekleþtireceðinibelirtiyoruz.

            app.UseRouting();

            app.UseAuthorization(); //login için yetki

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Listele}/{action=Index}/{id?}");
            });
        }
    }
}

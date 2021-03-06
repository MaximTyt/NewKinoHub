using KinoHab.Manager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewKinoHub.Manager;
using NewKinoHub.Manager.Accounts;
using NewKinoHub.Manager.Casts;
using NewKinoHub.Manager.Home;
using NewKinoHub.Manager.Persons;
using NewKinoHub.Manager.Userss;
using NewKinoHub.Models;
using NewKinoHub.Storage;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace NewKinoHub
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        [Obsolete]
        public Startup(IHostingEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<MvcFilmContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IHomeManager, HomeManager>();
            services.AddTransient<IFilmManager, FilmManager>();
            services.AddTransient<ICastManager, CastManager>();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddMvc();
            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

            });
           
            using (var scope = app.ApplicationServices.CreateScope())
            {
                MvcFilmContext content = scope.ServiceProvider.GetRequiredService<MvcFilmContext>();
                DBObjects.Initial(content);
            }
            
        }
    }
}


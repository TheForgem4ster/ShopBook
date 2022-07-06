using BusinessLayer.Interfaces;
using BusinessLayer.Repository;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    /// <summary>
    /// Starting class
    /// </summary>
    public class Startup
    {
        private IConfigurationRoot _confString;
        /// <summary>
        /// The constructor with the parameter refers to the folder where our database connection is stored
        /// </summary>
        /// <param name="hostEnv">Provides information to the web environment where the file is located</param>
        [System.Obsolete]
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer
            (_confString.GetConnectionString("DefaultConnection")));

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();


            // передаем интерфес который реализует класс (Объединяет интерфес с классом который реализует его)
            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IBooksCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // для двух пользователей будет выдана разная корзина 
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc(options => options.EnableEndpointRouting = false);

            //Указываем что мы используем кеш и сессии
            services.AddMemoryCache();
            services.AddSession();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            app.UseAuthentication();    
            app.UseAuthorization();     

            // Url address
            app.UseMvc(router =>
            {

                router.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                router.MapRoute(name: "categoryFilter", template: "Book/{action}/{category?}", defaults: new { Controllers = "Books", action = "List" });
                router.MapRoute(name: "FindBooks", template: "Book/{action}/{searchString?}", defaults: new { Controllers = "Books", action = "Find" });
            });
            // create an area
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Подключаем базу данных AppDBContent
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}

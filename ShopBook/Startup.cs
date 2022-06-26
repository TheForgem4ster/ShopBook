using BusinessLayer.Interfaces;
using BusinessLayer.Repository;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        [System.Obsolete]
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer
            (_confString.GetConnectionString("DefaultConnection")));

            // передаем интерфес который реализует класс
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

      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{


            //}
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();

            //Юрл адрес
            app.UseMvc(router =>
            {
                router.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                router.MapRoute(name: "categoryFilter", template: "Book/{action}/{category?}", defaults: new { Controllers = "Books", action = "List" });
            });
            // создаем область
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Подключаем базу данных AppDBContent
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}

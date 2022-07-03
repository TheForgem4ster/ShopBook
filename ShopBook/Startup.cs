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
    /// <summary>
    /// ��������� �����
    /// </summary>
    public class Startup
    {
        private IConfigurationRoot _confString;
        /// <summary>
        /// ����������� � ���������� ���������� � ����� ��� �������� ����������� ����� ���� ������
        /// </summary>
        /// <param name="hostEnv">������������� �������� ����� ���-���������� �����</param>
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

            // �������� �������� ������� ��������� ����� (���������� �������� � ������� ������� ��������� ���)
            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IBooksCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // ��� ���� ������������� ����� ������ ������ ������� 
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc(options => options.EnableEndpointRouting = false);

            //��������� ��� �� ���������� ��� � ������
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

            
            //��� �����
            app.UseMvc(router =>
            {

                router.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                router.MapRoute(name: "categoryFilter", template: "Book/{action}/{category?}", defaults: new { Controllers = "Books", action = "List" });
                router.MapRoute(name: "FindBooks", template: "Book/{action}/{searchString?}", defaults: new { Controllers = "Books", action = "Find" });
            });
            // ������� �������
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // ���������� ���� ������ AppDBContent
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}

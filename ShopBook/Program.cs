using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    /// <summary>
    /// ќсновной класс с которого начинаетс€ работа приложени€
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ќсновной метод с которого начинаетс€ точка входа приложени€
        /// ¬ котором мы создаем хост и запускаем его
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// —татический метод служит дл€ создани€ хоста(хоз€ина)
        /// </summary>
        /// <param name="args">массив строк</param>
        /// <returns> ѕринимает класс хоста который вызывает метод
        /// CreateDefaultBuilder который выполн€ет р€д задач:
        /// 1) ”станавливает корневой каталог (дл€ поиска содержимых) 
        /// 2) ”станавливает конфигурацию(совокупность настроек программ) хоста
        /// 3) ”станавливает конфигурацию приложени€
        /// ћетод ConfigureWebHostDefaults - выполн€ть конфигурацию параметров хоста:
        /// 1) «апускает и настраивает веб-сервер Kestrel
        /// 2) ƒобавл€ет компонент Host Filtering, который позвол€ет настраивать адреса
        /// ƒальше производитс€ инициализаци€ веб-сервера и устанавливаем стартовый класс  
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

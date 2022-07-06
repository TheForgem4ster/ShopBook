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
    /// The main class from which the application starts
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that starts the entry point of the application
        /// In which we create a host and run it
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// The static method is used to create a host
        /// </summary>
        /// <param name="args">string array</param>
        /// <returns> Принимает класс хоста который вызывает метод
        /// CreateDefaultBuilder который выполняет ряд задач:
        /// 1) Устанавливает корневой каталог (для поиска содержимых) 
        /// 2) Устанавливает конфигурацию(совокупность настроек программ) хоста
        /// 3) Устанавливает конфигурацию приложения
        /// Метод ConfigureWebHostDefaults - выполнять конфигурацию параметров хоста:
        /// 1) Запускает и настраивает веб-сервер Kestrel
        /// 2) Добавляет компонент Host Filtering, который позволяет настраивать адреса
        /// Дальше производится инициализация веб-сервера и устанавливаем стартовый класс  
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

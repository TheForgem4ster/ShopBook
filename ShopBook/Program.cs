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
        /// <returns> ��������� ����� ����� ������� �������� �����
        /// CreateDefaultBuilder ������� ��������� ��� �����:
        /// 1) ������������� �������� ������� (��� ������ ����������) 
        /// 2) ������������� ������������(������������ �������� ��������) �����
        /// 3) ������������� ������������ ����������
        /// ����� ConfigureWebHostDefaults - ��������� ������������ ���������� �����:
        /// 1) ��������� � ����������� ���-������ Kestrel
        /// 2) ��������� ��������� Host Filtering, ������� ��������� ����������� ������
        /// ������ ������������ ������������� ���-������� � ������������� ��������� �����  
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

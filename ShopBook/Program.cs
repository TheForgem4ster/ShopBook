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
    /// �������� ����� � �������� ���������� ������ ����������
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �������� ����� � �������� ���������� ����� ����� ����������
        /// � ������� �� ������� ���� � ��������� ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// ����������� ����� ������ ��� �������� �����(�������)
        /// </summary>
        /// <param name="args">������ �����</param>
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

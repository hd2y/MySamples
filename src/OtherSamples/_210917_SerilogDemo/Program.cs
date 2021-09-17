using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace _210917_SerilogDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("请输入要测试日志输出方式：\n1.默认\n2.Async\n3. 配置文件\n4.Async配置文件");
            var str = Console.ReadLine();
            if (str == "1") TestSerilogOutput();
            else if (str == "2") TestAsyncSerilogOutput();
            else if (str == "3") TestSerilogOutputByConfiguration();
            else if (str == "4") TestSerilogOutputByAsyncConfiguration();
        }

        static void TestSerilogOutput()
        {
            var list = GetObjList();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            var watch = new Stopwatch();
            watch.Start();

            Log.Information("Output:{@Data}", list);
            watch.Stop();

            Console.WriteLine($"日志输出，执行后续业务，耗时：{watch.ElapsedMilliseconds}ms");
            Log.CloseAndFlush();
        }

        static void TestAsyncSerilogOutput()
        {
            var list = GetObjList();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Async(
                    a =>
                        a.File("log.txt",
                            rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true)
                )
                .WriteTo.Async(a => a.Console())
                .CreateLogger();

            var watch = new Stopwatch();
            watch.Start();

            Log.Information("Output:{@Data}", list);
            watch.Stop();

            Console.WriteLine($"异步日志输出，执行后续业务，耗时：{watch.ElapsedMilliseconds}ms");
            Log.CloseAndFlush();
        }

        static void TestSerilogOutputByConfiguration()
        {
            TestSerilogOutputByConfigurationFile("appsettings.Serilog.json");
        }

        static void TestSerilogOutputByAsyncConfiguration()
        {
            TestSerilogOutputByConfigurationFile("appsettings.Async.json");
        }

        static void TestSerilogOutputByConfigurationFile(string fileName)
        {
            var list = GetObjList();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName)
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var watch = new Stopwatch();
            watch.Start();

            Log.Information("Output:{@Data}", list);
            watch.Stop();

            Console.WriteLine($"异步日志输出，执行后续业务，耗时：{watch.ElapsedMilliseconds}ms");
            Log.CloseAndFlush();
        }

        static List<TestObj> GetObjList()
        {
            return Enumerable.Range(0, 5000).Select(a => new TestObj
            {
                Name1 = $"Name1-{a}",
                Name2 = $"Name1-{a}",
                Name3 = $"Name1-{a}",
                Name4 = $"Name1-{a}",
            }).ToList();
        }

        public class TestObj
        {
            public string Name1 { get; set; }

            public DateTime Date1 { get; set; }
            public string Name2 { get; set; }

            public DateTime Date2 { get; set; }
            public string Name3 { get; set; }

            public DateTime Date3 { get; set; }
            public string Name4 { get; set; }

            public DateTime Date4 { get; set; }
            public int Inter1 { get; set; }

            public decimal Dec1 { get; set; }
            public int Inter2 { get; set; }

            public decimal Dec2 { get; set; }
            public int Inter3 { get; set; }

            public decimal Dec3 { get; set; }
        }
    }
}
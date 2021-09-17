using System;
using System.Diagnostics;
using System.Linq;
using Serilog;

namespace _210917_SerilogDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("请输入要测试日志输出方式：\n1.默认\n2.Async");
            var str = Console.ReadLine();
            if(str == "1") TestSerilogOutput();
            else if(str == "2") TestAsyncSerilogOutput();
            Console.ReadKey();
        }

        static void TestSerilogOutput()
        {
            var list = Enumerable.Range(0, 5000).Select(a => new TestObj
            {
                Name1 = $"Name1-{a}",
                Name2 = $"Name1-{a}",
                Name3 = $"Name1-{a}",
                Name4 = $"Name1-{a}",
            });
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true)
                .CreateLogger();

            var watch = new Stopwatch();
            watch.Start();

            Log.Information("Output:{Data}", list);
            watch.Stop();

            Console.WriteLine($"日志输出，执行后续业务，耗时：{watch.ElapsedMilliseconds}ms");
            Log.CloseAndFlush();
        }

        static void TestAsyncSerilogOutput()
        {
            var list = Enumerable.Range(0, 5000).Select(a => new TestObj
            {
                Name1 = $"Name1-{a}",
                Name2 = $"Name1-{a}",
                Name3 = $"Name1-{a}",
                Name4 = $"Name1-{a}",
            });
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Async(a =>
                {
                    a.File("log.txt",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true);
                    a.Console();
                })
                .CreateLogger();

            var watch = new Stopwatch();
            watch.Start();

            Log.Information("Output:{Data}", list);
            watch.Stop();

            Console.WriteLine($"异步日志输出，执行后续业务，耗时：{watch.ElapsedMilliseconds}ms");
            Log.CloseAndFlush();
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
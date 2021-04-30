using System;
using Anotar.Serilog;
using Serilog;

namespace AnotarSerilogSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            
            var myClass = new MyClass();
            myClass.TestDebug();
            myClass.TestException();
        }
    }

    public class MyClass
    {
        public void TestDebug()
        {
            LogTo.Debug("My name is {0}, I'm {1} years old.", "Li lei", 17);
        }

        [LogToErrorOnException]
        public void TestException()
        {
            throw new Exception("测试异常输出。");
        }
    }
}
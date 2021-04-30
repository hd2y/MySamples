using System;
using Anotar.NLog;

namespace AnotarNLogSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.TestDebug();
            myClass.TestTrace();
            myClass.TestException();
        }
    }

    public class MyClass
    {
        public void TestDebug()
        {
            LogTo.Debug("My name is {0}, I'm {1} years old.", "Li lei", 17);
        }

        public void TestTrace()
        {
            LogTo.Trace(() => "测试 Trace 输出.");
        }

        [LogToErrorOnException]
        public void TestException()
        {
            throw new Exception("测试异常输出。");
        }
    }
}
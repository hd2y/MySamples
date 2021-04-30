using System;
using Anotar.Custom;

namespace AnotarCustomSample
{
    class Program
    {
        static void Main(string[] args)
        {
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

    public class LoggerFactory
    {
        public static Logger GetLogger<T>() => new Logger();
    }

    public class Logger
    {
        public void Trace(string message) =>
            WriteLog("Debug", message, color: ConsoleColor.DarkGray);

        public void Trace(string format, params object[] args) =>
            WriteLog("Debug", format, args, color: ConsoleColor.DarkGray);

        public void Trace(Exception exception, string format, params object[] args) =>
            WriteLog("Debug", format, args, exception, color: ConsoleColor.DarkGray);

        public bool IsTraceEnabled { get; private set; }

        public void Debug(string message) =>
            WriteLog("Debug", message, color: ConsoleColor.Gray);

        public void Debug(string format, params object[] args) =>
            WriteLog("Debug", format, args, color: ConsoleColor.Gray);

        public void Debug(Exception exception, string format, params object[] args) =>
            WriteLog("Debug", format, args, exception, color: ConsoleColor.Gray);

        public bool IsDebugEnabled { get; private set; }

        public void Information(string message) =>
            WriteLog("Information", message);

        public void Information(string format, params object[] args) =>
            WriteLog("Information", format, args);

        public void Information(Exception exception, string format, params object[] args) =>
            WriteLog("Information", format, args, exception);

        public bool IsInformationEnabled { get; private set; }

        public void Warning(string message) =>
            WriteLog("Warning", message, color: ConsoleColor.DarkYellow);

        public void Warning(string format, params object[] args) =>
            WriteLog("Warning", format, args, color: ConsoleColor.DarkYellow);

        public void Warning(Exception exception, string format, params object[] args) =>
            WriteLog("Warning", format, args, exception, color: ConsoleColor.DarkYellow);

        public bool IsWarningEnabled { get; private set; }

        public void Error(string message) =>
            WriteLog("Error", message, color: ConsoleColor.Red);

        public void Error(string format, params object[] args) =>
            WriteLog("Error", format, args, color: ConsoleColor.Red);

        public void Error(Exception exception, string format, params object[] args) =>
            WriteLog("Error", format, args, exception, color: ConsoleColor.Red);

        public bool IsErrorEnabled { get; private set; }

        public void Fatal(string message) =>
            WriteLog("Fatal", message, color: ConsoleColor.DarkRed);

        public void Fatal(string format, params object[] args) =>
            WriteLog("Fatal", format, args, color: ConsoleColor.DarkRed);

        public void Fatal(Exception exception, string format, params object[] args) =>
            WriteLog("Fatal", format, args, exception, color: ConsoleColor.DarkRed);

        public bool IsFatalEnabled { get; private set; }

        private void WriteLog(string level, string format, object[] args = null, Exception exception = default,
            ConsoleColor? color = default)
        {
            lock (this)
            {
                Console.Write($"{DateTime.Now:HH:mm:ss.fff} ");

                if (color != default) Console.ForegroundColor = color.Value;
                Console.Write($"[{level}] ");
                if (color != default) Console.ResetColor();

                if (args == null) Console.WriteLine(format);
                else Console.WriteLine(format, args);

                if (exception == default) return;
                Console.WriteLine($"错误信息：{exception.Message}");
                Console.WriteLine($"堆栈跟踪：{exception.StackTrace}");
            }
        }
    }
}
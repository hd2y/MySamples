using System;
using System.IO;
using System.Reflection;

namespace BasicFodyAddinSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetEntryAssembly();
            var type = assembly?.GetType("Hello");
            if (type == null)
                Console.WriteLine("错误！");
            else
            {
                var hello = Activator.CreateInstance(type);
                var method = type.GetMethod("World");
                var result = method?.Invoke(hello, null) as string;
                Console.WriteLine(result);
            }
        }
    }
}
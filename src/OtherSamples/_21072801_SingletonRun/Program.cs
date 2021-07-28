using System;
using System.Threading;

namespace _21072801_SingletonRun
{
    class Program
    {
        private const string MutexKey = "7aac2339-d764-4216-8c73-dbd44399eb68";
        
        static void Main(string[] args)
        {
            var _ = new Mutex(true, MutexKey, out var createdNew);
            if (!createdNew)
            {
                Console.WriteLine("程序已运行，请不要重复启动，点击任意键退出...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("启动成功，点击任意键停止运行...");
            Console.ReadKey();
            Console.WriteLine("运行结束...");
        }
    }
}
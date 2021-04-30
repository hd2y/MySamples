using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AsyncErrorHandlerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler();
            var result = crawler.GetPageAsync("").GetAwaiter().GetResult();
            Console.WriteLine(result.Length);
        }
    }

    public class Crawler
    {
        public async Task<string> GetPageAsync(string url)
        {
            using var client = new WebClient();
            var result = await client.DownloadStringTaskAsync(url);
            return result;
        }
    }

    public static class AsyncErrorHandler
    {
        public static void HandleException(Exception exception)
        {
            Console.WriteLine("捕获了一个错误。");
            Console.WriteLine(exception.Message);
        }
    }
}
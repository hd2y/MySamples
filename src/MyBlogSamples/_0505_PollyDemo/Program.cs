using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;

namespace _0505_PollyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => { builder.AddConsole(); });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // 定义重试策略
            var retryPolicy = Policy.Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.BadGateway)
                .Retry(3, (exception, retryCount, context) => logger.LogInformation($"开始第 {retryCount} 次重试："));

            serviceCollection.AddHttpClient("RetryClient").AddTransientHttpErrorPolicy(builder => builder.OrResult(message => message.StatusCode == HttpStatusCode.BadGateway).RetryAsync(3,))

            // 执行具体任务
            var responseMessage = retryPolicy.Execute(() =>
            {
                // 模拟网络请求
                logger.LogInformation("正在执行网络请求...");

                // 模拟网络错误
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            });

            logger.LogInformation("结束返回状态：{StatusCode}", responseMessage.StatusCode);
        }
    }
}
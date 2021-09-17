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
            #region 测试

            // IServiceCollection serviceCollection = new ServiceCollection();
            // serviceCollection.AddLogging(builder => { builder.AddConsole(); });
            //
            // var serviceProvider = serviceCollection.BuildServiceProvider();
            // var logger = serviceProvider.GetService<ILogger<Program>>();
            //
            // // 定义重试策略
            // var retryPolicy = Policy.Handle<HttpRequestException>()
            //     .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.BadGateway)
            //     .Retry(3, (exception, retryCount, context) => logger.LogInformation($"开始第 {retryCount} 次重试："));
            //
            // serviceCollection.AddHttpClient("RetryClient").AddTransientHttpErrorPolicy(builder => builder.OrResult(message => message.StatusCode == HttpStatusCode.BadGateway).RetryAsync(3,))
            //
            // // 执行具体任务
            // var responseMessage = retryPolicy.Execute(() =>
            // {
            //     // 模拟网络请求
            //     logger.LogInformation("正在执行网络请求...");
            //
            //     // 模拟网络错误
            //     return new HttpResponseMessage(HttpStatusCode.BadGateway);
            // });
            //
            // logger.LogInformation("结束返回状态：{StatusCode}", responseMessage.StatusCode);

            #endregion

            // 单个异常类型
            Policy
                .Handle<HttpRequestException>();

            // 带条件的单个异常类型
            Policy
                .Handle<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.InternalServerError);

            // 多个异常类型
            Policy
                .Handle<HttpRequestException>()
                .Or<OperationCanceledException>();

            // 待条件的多个异常类型
            Policy
                .Handle<HttpRequestException>(ex => ex.StatusCode == HttpStatusCode.InternalServerError)
                .Or<ArgumentException>(ex => ex.ParamName == "example");

            // 带条件或不带条件的内部异常或 AggregateException
            // (HandleInner 方法会同时匹配顶层以及内部异常)
            Policy
                .HandleInner<HttpRequestException>()
                .OrInner<ArgumentException>(ex => ex.ParamName == "example");
        }
    }
}
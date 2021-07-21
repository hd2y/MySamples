using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _0502_HttpClientFactoryDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 获取配置
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", false, true);
            var configurationRoot = configurationBuilder.Build();

            // 注册日志
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddConfiguration(configurationRoot.GetSection("Logging"));
                builder.AddConsole();
            });

            // 注册 DelegatingHandler
            serviceCollection.AddSingleton<TestHttpHandler>();

            // // 工厂模式注册 HttpClientFactory
            //serviceCollection.AddHttpClient();

            // // 命名客户端模式注册 HttpClientFactory
            // var httpClientBuilder = serviceCollection.AddHttpClient("Baidu")
            //     .SetHandlerLifetime(TimeSpan.FromHours(1))
            //     .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(10))
            //     .AddHttpMessageHandler<TestHttpHandler>();

            // 命名客户端模式注册 HttpClientFactory
            var httpClientBuilder = serviceCollection.AddHttpClient<TypedHttpClient>()
                .SetHandlerLifetime(TimeSpan.FromHours(1))
                .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(10));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // // 工厂模式
            // var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            // var client = httpClientFactory.CreateClient();
            // var result = await client.GetStringAsync("https://www.baidu.com");
            // logger.LogInformation("内容长度：{ContentLength}", result.Length);

            // // 命名客户端模式
            // var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            // var client = httpClientFactory.CreateClient("Baidu");
            // var result = await client.GetStringAsync("https://www.baidu.com");
            // logger.LogInformation("内容长度：{ContentLength}", result.Length);

            // 类型客户端模式
            var typedHttpClient = serviceProvider.GetService<TypedHttpClient>();
            var result = await typedHttpClient.GetStringAsync("https://www.baidu.com");
            logger.LogInformation("内容长度：{ContentLength}", result.Length);

            Console.ReadKey();
        }
    }

    public class TestHttpHandler : DelegatingHandler
    {
        private readonly ILogger<TestHttpHandler> _logger;

        public TestHttpHandler(ILogger<TestHttpHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("{Name} Start.", nameof(TestHttpHandler));
            var result = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation("{Name} End.", nameof(TestHttpHandler));
            return result;
        }
    }

    public class TypedHttpClient
    {
        private readonly HttpClient _client;

        public TypedHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetStringAsync(string requestUri, CancellationToken cancellationToken = default)
        {
            return await _client.GetStringAsync(requestUri, cancellationToken);
        }
    }
}
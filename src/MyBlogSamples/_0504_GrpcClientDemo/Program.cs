using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServices;
using Microsoft.Extensions.DependencyInjection;

namespace _0504_GrpcClientDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // .NET 3.x 配置允许使用不加密的 HTTP/2 协议
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            // 依赖注入的方式获取客户端
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddGrpcClient<UserGrpc.UserGrpcClient>(options =>
            {
                options.Address = new Uri("https://localhost:5001");
            });
            
            // // 使用自签名证书，验证证书时永远返回 True
            // serviceCollection.AddGrpcClient<UserGrpc.UserGrpcClient>(options =>
            // {
            //     options.Address = new Uri("https://localhost:5001");
            // }).ConfigurePrimaryHttpMessageHandler(_ =>
            //     new SocketsHttpHandler
            //     {
            //         SslOptions = {RemoteCertificateValidationCallback = (_, _, _, _) => true}
            //     });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var client = serviceProvider.GetService<UserGrpc.UserGrpcClient>();

            // // 通过 GrpcChannel 获取客户端
            // var channel = GrpcChannel.ForAddress("http://localhost:5000");
            // var client = new UserGrpc.UserGrpcClient(channel);

            while (true)
            {
                try
                {
                    var createUserResult = await client.CreateUserAsync(new CreateUserCommand
                    {
                        Name = "Test",
                        Nickname = "TEST",
                        IsAdmin = false,
                        Password = "abc123"
                    });

                    Console.WriteLine("CreateUser result of user id: " + createUserResult.UserId);
                }
                catch (RpcException e)
                {
                    Console.WriteLine(e.Message);
                    var message = e.Trailers.Get("message-bin");
                    if (message?.ValueBytes != null)
                    {
                        Console.WriteLine(Encoding.UTF8.GetString(message.ValueBytes));
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
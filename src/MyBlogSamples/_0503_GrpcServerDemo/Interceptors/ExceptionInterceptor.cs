using System;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace _0503_GrpcServerDemo.Interceptors
{
    public class ExceptionInterceptor : Interceptor
    {
        private readonly ILogger<ExceptionInterceptor> _logger;

        public ExceptionInterceptor(ILogger<ExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await base.UnaryServerHandler(request, context, continuation);
            }
            // 再次之前处理业务异常并返回
            catch (Exception e)
            {
                _logger.LogWarning(e, "gRPC 服务调用过程出现未处理异常");

                var metadata = new Metadata {{"message-bin", Encoding.UTF8.GetBytes(e.Message)}};
                throw new RpcException(new Status(StatusCode.Internal, "未处理的异常信息"), metadata);
            }
        }
    }
}
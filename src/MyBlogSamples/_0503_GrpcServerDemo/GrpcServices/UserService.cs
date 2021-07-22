using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServices;
using Microsoft.Extensions.Logging;

namespace _0503_GrpcServerDemo.GrpcServices
{
    public class UserService : UserGrpc.UserGrpcBase
    {
        private static int id = 1;
        private static ConcurrentDictionary<string, int> Users = new ConcurrentDictionary<string, int>();
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger) => _logger = logger;

        public override Task<CreateUserResult> CreateUser(CreateUserCommand request, ServerCallContext context)
        {
            // 编写业务逻辑
            // ...
            if (Users.TryGetValue(request.Name, out var userId))
                throw new Exception($"用户[{request.Name}]已存在，用户ID为 {userId}！");

            userId = id++;
            _logger.LogInformation(
                "CreateUser: Name {Name}, Nickname {Nickname}, IsAdmin {IsAdmin}, Password {Password} Result: {UserId}",
                request.Name, request.Nickname, request.IsAdmin, request.Password, userId);
            
            if(!Users.TryAdd(request.Name, userId))
                throw new Exception($"用户[{request.Name}]存储用户ID为 {userId} 失败！");
            
            return Task.FromResult(new CreateUserResult()
            {
                UserId = userId
            });
        }
    }
}
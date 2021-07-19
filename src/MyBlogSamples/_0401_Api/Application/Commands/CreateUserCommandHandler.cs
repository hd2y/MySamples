using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using MediatR;
using MyBlog.Domain.UserAggregate;
using MyBlog.Infrastructure.Repositories;

namespace MyBlog.Api.Application.Commands
{
    /// <summary>
    /// 创建用户命令处理程序
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICapPublisher _capPublisher;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="capPublisher"></param>
        public CreateUserCommandHandler(IUserRepository userRepository, ICapPublisher capPublisher)
        {
            _userRepository = userRepository;
            _capPublisher = capPublisher;
        }

        /// <summary>
        /// 处理用户创建
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Nickname, request.Email, request.Tel, request.IsAdmin,
                request.Password);
            await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return user.Id;
        }
    }
}
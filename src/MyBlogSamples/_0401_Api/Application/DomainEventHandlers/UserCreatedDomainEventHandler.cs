using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using MyBlog.Api.Application.IntegrationEvents;
using MyBlog.Domain.Abstractions;
using MyBlog.Domain.Events;

namespace MyBlog.Api.Application.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler : IDomainEventHandler<UserCreatedDomainEvent>
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<UserCreatedDomainEventHandler> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capPublisher"></param>
        public UserCreatedDomainEventHandler(ICapPublisher capPublisher, ILogger<UserCreatedDomainEventHandler> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("添加用户 {UserId}", notification.User.Id);
            await _capPublisher.PublishAsync("UserCreated", new UserCreatedIntegrationEvent(notification.User.Id),
                cancellationToken: cancellationToken);
        }
    }
}
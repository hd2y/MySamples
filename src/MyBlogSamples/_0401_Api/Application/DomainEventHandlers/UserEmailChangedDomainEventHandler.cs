using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using MyBlog.Api.Application.IntegrationEvents;
using MyBlog.Domain.Abstractions;
using MyBlog.Domain.Events;

namespace MyBlog.Api.Application.DomainEventHandlers
{
    /// <summary>
    /// 用户邮箱变更领域事件处理程序
    /// </summary>
    public class UserEmailChangedDomainEventHandler : IDomainEventHandler<UserEmailChangedDomainEvent>
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<UserEmailChangedDomainEventHandler> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capPublisher"></param>
        /// <param name="logger"></param>
        public UserEmailChangedDomainEventHandler(ICapPublisher capPublisher,
            ILogger<UserEmailChangedDomainEventHandler> logger)
        {
            _capPublisher = capPublisher;
            _logger = logger;
        }

        /// <summary>
        /// 处理邮箱变更
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(UserEmailChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("用户 {UserId} 变更邮箱 {Email}", notification.User.Id, notification.User.Email);
            await _capPublisher.PublishAsync("UserEmailChanged",
                new UserEmailChangedIntegrationEvent(notification.User.Id, notification.User.Email),
                cancellationToken: cancellationToken);
        }
    }
}
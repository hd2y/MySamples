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
    /// 创建文章领域事件处理程序
    /// </summary>
    public class PostCreatedDomainEventHandler : IDomainEventHandler<PostCreatedDomainEvent>
    {
        private readonly ICapPublisher _capPublisher;
        private readonly ILogger<PostCreatedDomainEventHandler> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capPublisher"></param>
        /// <param name="logger"></param>
        public PostCreatedDomainEventHandler(ICapPublisher capPublisher, ILogger<PostCreatedDomainEventHandler> logger)
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
        public async Task Handle(PostCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("新增文章 {PostId}", notification.Post.Id);
            await _capPublisher.PublishAsync("PostCreated", new PostCreatedIntegrationEvent(notification.Post.Id),
                cancellationToken: cancellationToken);
        }
    }
}
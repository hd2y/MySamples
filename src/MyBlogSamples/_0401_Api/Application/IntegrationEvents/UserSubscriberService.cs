using DotNetCore.CAP;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MyBlog.Api.Application.IntegrationEvents
{
    /// <summary>
    /// 用户订阅处理服务
    /// </summary>
    public class UserSubscriberService : IUserSubscriberService, ICapSubscribe
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserSubscriberService> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public UserSubscriberService(IMediator mediator, ILogger<UserSubscriberService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 用户创建订阅处理函数
        /// </summary>
        /// <param name="integrationEvent"></param>
        [CapSubscribe("UserCreated")]
        public void UserCreated(UserCreatedIntegrationEvent integrationEvent)
        {
            _logger.LogInformation("订阅者接收到消息：{IntegrationEvent} {UserId}", nameof(UserCreated),
                integrationEvent.UserId);

            // 接收后处理指定业务...
        }
    }
}
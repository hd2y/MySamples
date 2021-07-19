// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Api.Application.IntegrationEvents
{
    /// <summary>
    /// 创建用户集成事件
    /// </summary>
    public class UserCreatedIntegrationEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId"></param>
        public UserCreatedIntegrationEvent(long userId) => UserId = userId;

        /// <summary>
        /// 用户 ID
        /// </summary>
        public long UserId { get; }
    }
}
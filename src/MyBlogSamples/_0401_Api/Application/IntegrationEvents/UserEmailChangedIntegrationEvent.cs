// ReSharper disable MemberCanBePrivate.Global
namespace MyBlog.Api.Application.IntegrationEvents
{
    /// <summary>
    /// 用户邮箱变更集成事件
    /// </summary>
    public class UserEmailChangedIntegrationEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        public UserEmailChangedIntegrationEvent(long userId, string email)
        {
            UserId = userId;
            Email = email;
        }
        
        /// <summary>
        /// 用户 ID
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; }
    }
}
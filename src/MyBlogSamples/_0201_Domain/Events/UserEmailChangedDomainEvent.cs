using MyBlog.Domain.Abstractions;
using MyBlog.Domain.UserAggregate;

namespace MyBlog.Domain.Events
{
    /// <summary>
    /// 用户更新邮箱信息
    /// </summary>
    public class UserEmailChangedDomainEvent: IDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user"></param>
        public UserEmailChangedDomainEvent(User user)
        {
            User = user;
        }

        /// <summary>
        /// 更新邮箱用户
        /// </summary>
        public User User { get; private set; }
    }
}
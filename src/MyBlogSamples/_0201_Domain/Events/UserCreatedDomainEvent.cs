using MyBlog.Domain.Abstractions;
using MyBlog.Domain.UserAggregate;

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.Events
{
    /// <summary>
    /// 创建用户领域事件
    /// </summary>
    public class UserCreatedDomainEvent : IDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user"></param>
        public UserCreatedDomainEvent(User user)
        {
            User = user;
        }

        /// <summary>
        /// 新添加的用户
        /// </summary>
        public User User { get; private set; }
    }
}
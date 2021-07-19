using MyBlog.Domain.Abstractions;
using MyBlog.Domain.PostAggregate;
// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.Events
{
    /// <summary>
    /// 发布文章事件
    /// </summary>
    public class PostCreatedDomainEvent : IDomainEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="post"></param>
        public PostCreatedDomainEvent(Post post)
        {
            Post = post;
        }

        /// <summary>
        /// 发布的文章
        /// </summary>
        public Post Post { get; private set; }
    }
}
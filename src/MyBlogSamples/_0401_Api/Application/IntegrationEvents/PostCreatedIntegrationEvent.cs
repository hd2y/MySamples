// ReSharper disable MemberCanBePrivate.Global
namespace MyBlog.Api.Application.IntegrationEvents
{
    /// <summary>
    /// 新增文章集成事件
    /// </summary>
    public class PostCreatedIntegrationEvent
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="postId"></param>
        public PostCreatedIntegrationEvent(long postId) => PostId = postId;
        
        /// <summary>
        /// 文章 ID
        /// </summary>
        public long PostId { get; }
    }
}
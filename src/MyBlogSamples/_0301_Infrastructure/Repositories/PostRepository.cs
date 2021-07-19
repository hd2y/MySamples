using MyBlog.Domain.PostAggregate;
using MyBlog.Infrastructure.Core;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// 文章仓储
    /// </summary>
    public class PostRepository : Repository<Post, long, BlogContext>, IPostRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public PostRepository(BlogContext context) : base(context)
        {
        }
    }
}
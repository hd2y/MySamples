using MyBlog.Domain.PostAggregate;
using MyBlog.Infrastructure.Core;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// 文章仓储接口
    /// </summary>
    public interface IPostRepository : IRepository<Post, long>
    {
    }
}
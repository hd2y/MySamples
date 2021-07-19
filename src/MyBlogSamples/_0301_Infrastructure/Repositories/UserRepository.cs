using MyBlog.Domain.UserAggregate;
using MyBlog.Infrastructure.Core;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// 文章仓储
    /// </summary>
    public class UserRepository : Repository<User, long, BlogContext>, IUserRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(BlogContext context) : base(context)
        {
        }
    }
}
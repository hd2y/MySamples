using MyBlog.Domain.UserAggregate;
using MyBlog.Infrastructure.Core;

namespace MyBlog.Infrastructure.Repositories
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User, long>
    {
    }
}
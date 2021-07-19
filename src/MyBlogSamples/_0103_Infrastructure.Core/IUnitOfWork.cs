using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Core
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>受影响数量</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>是否成功</returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
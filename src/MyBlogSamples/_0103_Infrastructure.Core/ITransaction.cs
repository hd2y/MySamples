using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyBlog.Infrastructure.Core
{
    /// <summary>
    /// 事务接口
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// 获取当前事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction GetCurrentTransaction();

        /// <summary>
        /// 已经存在事务
        /// </summary>
        bool HasActiveTransaction { get; }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);

        /// <summary>
        /// 事务回滚
        /// </summary>
        void RollbackTransaction();
    }
}
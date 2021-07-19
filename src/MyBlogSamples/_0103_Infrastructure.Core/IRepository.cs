using System.Threading;
using System.Threading.Tasks;
using MyBlog.Domain.Abstractions;

namespace MyBlog.Infrastructure.Core
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : Entity, IAggregateRoot
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Remove(Entity entity);
        
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> RemoveAsync(Entity entity);
    }

    /// <summary>
    /// 指定主键类型的仓储接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, in TKey> : IRepository<TEntity> where TEntity : Entity<TKey>, IAggregateRoot
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(TKey id);
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBlog.Infrastructure.Core.Extensions;

namespace MyBlog.Infrastructure.Core
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class EFContext : DbContext, IUnitOfWork, ITransaction
    {
        private readonly IMediator _mediator;
        private readonly ICapPublisher _capBus;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        /// <param name="mediator"></param>
        /// <param name="capBus"></param>
        public EFContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options)
        {
            _mediator = mediator;
            _capBus = capBus;
        }

        #region IUnitOfWork

        /// <summary>
        /// 保存变更
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var _ = await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
            return true;
        }

        #endregion

        #region ITransaction

        private IDbContextTransaction _currentTransaction;

        /// <summary>
        /// 获取当前事务
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        /// <summary>
        /// 是否开启事务
        /// </summary>
        public bool HasActiveTransaction => _currentTransaction != null;

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns>数据库事务</returns>
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;
            _currentTransaction = Database.BeginTransaction(_capBus, autoCommit: false);
            return Task.FromResult(_currentTransaction);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        /// <exception cref="ArgumentNullException">事务为空</exception>
        /// <exception cref="InvalidOperationException">事务与当前事务不一致</exception>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction)
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        #endregion
    }
}
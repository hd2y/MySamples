using Microsoft.Extensions.Logging;
using MyBlog.Infrastructure.Core.Behaviors;

namespace MyBlog.Infrastructure
{
    /// <summary>
    /// 博客数据库访问事务处理
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class BlogContextTransactionBehavior<TRequest, TResponse>
        : TransactionBehavior<BlogContext, TRequest, TResponse>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        public BlogContextTransactionBehavior(BlogContext dbContext,
            ILogger<BlogContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
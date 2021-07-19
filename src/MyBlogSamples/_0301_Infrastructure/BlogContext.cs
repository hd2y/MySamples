using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.PostAggregate;
using MyBlog.Domain.UserAggregate;
using MyBlog.Infrastructure.Core;
using MyBlog.Infrastructure.EntityConfigurations;

namespace MyBlog.Infrastructure
{
    /// <summary>
    /// 博客访问数据库上下文
    /// </summary>
    public class BlogContext : EFContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        /// <param name="mediator"></param>
        /// <param name="capBus"></param>
        public BlogContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options, mediator,
            capBus)
        {
        }

        /// <summary>
        /// 访问用户
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 访问文章
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
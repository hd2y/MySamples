using System;
using DotNetCore.CAP;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Domain.PostAggregate;
using MyBlog.Infrastructure;
using MyBlog.Infrastructure.Repositories;
using Savorboard.CAP.InMemoryMessageQueue;

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Api.Extensions
{
    /// <summary>
    /// ServiceCollection 扩展方法
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 添加 MediatR
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BlogContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Post).Assembly, typeof(Program).Assembly);
        }

        /// <summary>
        /// 添加数据库访问
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomainContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<BlogContext>(optionsAction);
        }

        /// <summary>
        /// 添加 MySQL 数据库访问
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conn">连接字符串</param>
        /// <returns></returns>
        public static IServiceCollection AddMySqlDomainContext(this IServiceCollection services, string conn)
        {
            return services.AddDomainContext(builder => builder.UseMySql(conn, ServerVersion.AutoDetect(conn)));
        }

        /// <summary>
        /// 添加事件总线
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<ISubscriberService, SubscriberService>();
            services.AddCap(options =>
            {
                // 存储
                options.UseMySql(configuration.GetValue<string>("MySql"));
                // options.UseEntityFramework<BlogContext>();

                // 传输
                options.UseInMemoryMessageQueue();
                // options.UseRabbitMQ(options =>
                // {
                //     configuration.GetSection("RabbitMQ").Bind(options);
                // });
                
                // 监控
                // options.UseDashboard();
            });

            return services;
        }
        
        /// <summary>
        /// 注册仓储
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }
    }
}
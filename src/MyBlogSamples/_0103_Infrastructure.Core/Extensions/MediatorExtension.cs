using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Abstractions;

namespace MyBlog.Infrastructure.Core.Extensions
{
    /// <summary>
    /// Mediator 扩展方法
    /// </summary>
    public static class MediatorExtension
    {
        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="ctx"></param>
        /// <param name="cancellationToken"></param>
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx,
            CancellationToken cancellationToken = default)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent, cancellationToken);
        }
    }
}
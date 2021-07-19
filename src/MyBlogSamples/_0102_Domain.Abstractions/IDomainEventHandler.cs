using MediatR;

namespace MyBlog.Domain.Abstractions
{
    /// <summary>
    /// 领域事件处理程序
    /// </summary>
    /// <typeparam name="TDomainEvent">领域事件</typeparam>
    public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}
using MediatR;

namespace MyBlog.Domain.Abstractions
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public interface IDomainEvent : INotification
    {
    }
}
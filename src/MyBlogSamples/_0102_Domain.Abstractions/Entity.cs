using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.Abstractions
{
    /// <summary>
    /// 实体类型
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns>主键值，联合主键返回多个</returns>
        public abstract object[] GetKeys();

        /// <summary>
        /// 转字符串
        /// </summary>
        /// <returns>实体类型和主键值</returns>
        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Keys = {string.Join(",", GetKeys())}";
        }

        #region

        /// <summary>
        /// 领域事件
        /// </summary>
        private List<IDomainEvent> _domainEvents;

        /// <summary>
        /// 领域事件
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        /// <summary>
        /// 添加领域事件
        /// </summary>
        /// <param name="eventItem">需要添加的领域事件</param>
        protected void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// 移除领域事件
        /// </summary>
        /// <param name="eventItem">需要移除的领域事件</param>
        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        /// <summary>
        /// 清除绑定的所有领域事件
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        #endregion
    }

    /// <summary>
    /// 单主键实体
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        /// <summary>
        /// 请求的 HashCode
        /// </summary>
        private int? _requestedHashCode;

        /// <summary>
        /// 主键
        /// </summary>
        public virtual TKey Id { get; protected set; }

        /// <summary>
        /// 获取主键
        /// </summary>
        /// <returns></returns>
        public override object[] GetKeys()
        {
            return new object[] {Id};
        }

        /// <summary>
        /// 判断实体是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TKey> entity))
                return false;

            if (ReferenceEquals(this, entity))
                return true;

            if (GetType() != entity.GetType())
                return false;

            if (entity.IsTransient() || IsTransient())
                return false;
            return entity.Id.Equals(Id);
        }

        /// <summary>
        /// 获取 HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (IsTransient()) return base.GetHashCode();

            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }


        /// <summary>
        /// 判断是否为新创建实体，未持久化保存
        /// </summary>
        /// <returns>实体是否为新创建的</returns>
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default);
        }

        /// <summary>
        /// 转字符串的方法
        /// </summary>
        /// <returns>实体类型名以及主键值</returns>
        public override string ToString()
        {
            return $"[Entity: {GetType().Name}] Id = {Id}";
        }

        /// <summary>
        /// 相等判断
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        /// <summary>
        /// 不等判断
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
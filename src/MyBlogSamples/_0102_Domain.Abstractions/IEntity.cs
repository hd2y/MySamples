namespace MyBlog.Domain.Abstractions
{
    /// <summary>
    /// 实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取主键值
        /// </summary>
        /// <returns>主键值，如果是联合主键返回多个</returns>
        object[] GetKeys();
    }

    /// <summary>
    /// 指定主键类型的实体接口
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey Id { get; }
    }
}
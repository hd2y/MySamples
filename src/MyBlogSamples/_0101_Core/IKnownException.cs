namespace MyBlog.Core
{
    /// <summary>
    /// 已知异常接口
    /// </summary>
    public interface IKnownException
    {
        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; }

        /// <summary>
        /// 错误码
        /// </summary>
        int ErrorCode { get; }

        /// <summary>
        /// 错误数据
        /// </summary>
        object[] ErrorData { get; }
    }
}
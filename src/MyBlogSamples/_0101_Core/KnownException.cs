namespace MyBlog.Core
{
    /// <summary>
    /// 已知异常
    /// </summary>
    public class KnownException : IKnownException
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// 错误数据
        /// </summary>
        public object[] ErrorData { get; private set; }

        /// <summary>
        /// 未知异常
        /// </summary>
        public static readonly IKnownException Unknown = new KnownException {Message = "未知错误", ErrorCode = 9999};

        /// <summary>
        /// 从已知异常信息中重新构造异常信息
        /// </summary>
        /// <param name="exception">已知异常</param>
        /// <returns>已知异常信息</returns>
        public static IKnownException FromKnownException(IKnownException exception)
        {
            return new KnownException
                {Message = exception.Message, ErrorCode = exception.ErrorCode, ErrorData = exception.ErrorData};
        }
    }
}
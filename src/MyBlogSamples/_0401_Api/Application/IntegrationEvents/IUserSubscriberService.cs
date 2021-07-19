namespace MyBlog.Api.Application.IntegrationEvents
{
    /// <summary>
    /// 用户订阅处理服务接口
    /// </summary>
    public interface IUserSubscriberService
    {
        /// <summary>
        /// 用户创建订阅处理函数
        /// </summary>
        /// <param name="integrationEvent"></param>
        void UserCreated(UserCreatedIntegrationEvent integrationEvent);
    }
}
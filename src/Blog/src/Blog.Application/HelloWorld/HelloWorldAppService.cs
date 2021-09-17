using Volo.Abp.Application.Services;

namespace Blog.HelloWorld
{
    public class HelloWorldAppService : ApplicationService, IHelloWorldAppService
    {
        public string HelloWorld()
        {
            return "hello world!";
        }
    }
}
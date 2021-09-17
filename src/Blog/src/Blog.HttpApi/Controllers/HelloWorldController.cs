using Blog.HelloWorld;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : AbpController
    {
        private IHelloWorldAppService HelloWorldAppService =>
            LazyServiceProvider.LazyGetRequiredService<IHelloWorldAppService>();

        [HttpGet]
        public string HelloWorld()
        {
            return HelloWorldAppService.HelloWorld();
        }
    }
}
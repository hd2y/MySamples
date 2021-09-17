using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
    )]
    public class BlogDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<BlogOptions>(options => configuration.GetSection("Blog").Bind(options));
        }
    }
}
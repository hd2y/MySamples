using Blog.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(BlogApplicationContractsModule),
        typeof(BlogApplicationCachingModule),
        typeof(BlogDomainModule)
    )]
    public class BlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<BlogApplicationModule>(); });
        }
    }
}
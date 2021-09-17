using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Blog.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(BlogDomainModule)
    )]
    public class BlogApplicationCachingModule : AbpModule
    {
    }
}
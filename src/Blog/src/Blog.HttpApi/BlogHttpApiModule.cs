using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(BlogApplicationContractsModule)
    )]
    public class BlogHttpApiModule : AbpModule
    {
    }
}
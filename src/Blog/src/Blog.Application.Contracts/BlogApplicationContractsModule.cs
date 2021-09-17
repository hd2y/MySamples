using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
        typeof(BlogDomainSharedModule)
    )]
    public class BlogApplicationContractsModule : AbpModule
    {
    }
}

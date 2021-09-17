using Blog.PostTags;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.PostTags
{
    public class EfCorePostTagRepository : EfCoreRepository<BlogDbContext, PostTag, int>, IPostTagRepository
    {
        public EfCorePostTagRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
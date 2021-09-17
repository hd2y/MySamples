using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Blog.Tags;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.Tags
{
    public class EfCoreTagRepository : EfCoreRepository<BlogDbContext, Tag, int>, ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
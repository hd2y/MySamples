using Blog.FriendLinks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.FriendLinks
{
    public class EfCoreFriendLinkRepository : EfCoreRepository<BlogDbContext, FriendLink, int>, IFriendLinkRepository
    {
        public EfCoreFriendLinkRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
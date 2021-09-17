using Volo.Abp.Domain.Repositories;

namespace Blog.FriendLinks
{
    public interface IFriendLinkRepository : IRepository<FriendLink, int>
    {
    }
}
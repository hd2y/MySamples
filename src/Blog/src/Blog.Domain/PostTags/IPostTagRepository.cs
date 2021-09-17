using Volo.Abp.Domain.Repositories;

namespace Blog.PostTags
{
    public interface IPostTagRepository : IRepository<PostTag, int>
    {
    }
}
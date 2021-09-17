using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Blog.Posts
{
    public interface IPostRepository : IRepository<Post, int>
    {
        Task<List<Post>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}
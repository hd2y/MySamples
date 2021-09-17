using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Blog.Posts;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.Posts
{
    public class EfCorePostRepository : EfCoreRepository<BlogDbContext, Post, int>, IPostRepository
    {
        public EfCorePostRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Post>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    post => post.Title.Contains(filter) || post.Author.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(cancellationToken);
        }
    }
}
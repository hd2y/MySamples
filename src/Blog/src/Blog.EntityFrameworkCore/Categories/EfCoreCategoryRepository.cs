using System.Threading;
using System.Threading.Tasks;
using Blog.Categories;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore.Categories
{
    public class EfCoreCategoryRepository : EfCoreRepository<BlogDbContext, Category, int>, ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<BlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<Category> InsertAsync(
            [NotNull] Category entity,
            bool autoSave = false,
            CancellationToken cancellationToken = default
        )
        {
            Check.NotNull(entity, nameof(entity));

            var dbSet = await GetDbSetAsync();
            if (await dbSet.AnyAsync(category => category.CategoryName == entity.CategoryName, cancellationToken))
            {
                throw new CategoryAlreadyExistsException(entity.CategoryName);
            }

            return await base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Blog.Categories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
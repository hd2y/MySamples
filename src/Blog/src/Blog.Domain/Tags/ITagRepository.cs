using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Blog.Tags
{
    public interface ITagRepository : IRepository<Tag, int>
    {
    }
}
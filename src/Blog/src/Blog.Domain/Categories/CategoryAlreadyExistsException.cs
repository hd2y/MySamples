using Volo.Abp;

namespace Blog.Categories
{
    public class CategoryAlreadyExistsException : BusinessException
    {
        public CategoryAlreadyExistsException(string categoryName) : base(BlogDomainErrorCode.CategoryAlreadyExists)
        {
            WithData("name", categoryName);
        }
    }
}
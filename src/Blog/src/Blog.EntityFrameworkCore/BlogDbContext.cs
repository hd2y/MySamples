using Blog.Categories;
using Blog.FriendLinks;
using Blog.Posts;
using Blog.PostTags;
using Blog.Tags;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Blog.EntityFrameworkCore
{
    [ConnectionStringName("Blog")]
    public class BlogDbContext :
        AbpDbContext<BlogDbContext>
    {
        #region Entities from the modules
        
        // Blog
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }

        #endregion

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
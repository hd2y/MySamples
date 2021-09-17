using Blog.Categories;
using Blog.FriendLinks;
using Blog.Posts;
using Blog.PostTags;
using Blog.Tags;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Blog.EntityFrameworkCore
{
    public static class BlogDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Post>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogDbConsts.DbTableName.Posts);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(200).IsRequired();
                b.Property(x => x.Author).HasMaxLength(10);
                b.Property(x => x.Url).HasMaxLength(100).IsRequired();
                b.Property(x => x.Html).IsRequired();
                b.Property(x => x.Markdown).IsRequired();
                b.Property(x => x.CategoryId);
                b.Property(x => x.CreationTime);
            });

            builder.Entity<Category>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogDbConsts.DbTableName.Categories);
                b.HasKey(x => x.Id);
                b.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tag>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogDbConsts.DbTableName.Tags);
                b.HasKey(x => x.Id);
                b.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<PostTag>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogDbConsts.DbTableName.PostTags);
                b.HasKey(x => x.Id);
                b.Property(x => x.PostId).IsRequired();
                b.Property(x => x.TagId).IsRequired();
            });

            builder.Entity<FriendLink>(b =>
            {
                b.ToTable(BlogConsts.DbTablePrefix + BlogDbConsts.DbTableName.FriendLinks);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(20).IsRequired();
                b.Property(x => x.LinkUrl).HasMaxLength(100).IsRequired();
            });
        }
    }
}
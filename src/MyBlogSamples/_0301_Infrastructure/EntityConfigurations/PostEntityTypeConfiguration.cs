using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.PostAggregate;

namespace MyBlog.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 文章实体类型配置
    /// </summary>
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasComment("主键");
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired().HasComment("标题");
            builder.Property(p => p.Slug).HasMaxLength(200).IsRequired().HasComment("连字符名称");
            builder.Property(p => p.OriginalContent).IsRequired().HasComment("原始内容");
            builder.Property(p => p.FormatContent).IsRequired().HasComment("格式化后内容");
            builder.Property(p => p.EditType).HasDefaultValue(0).HasComment("编辑器类型");
            builder.Property(p => p.Type).HasDefaultValue(0).HasComment("类型");
            builder.Property(p => p.CreateFrom).HasDefaultValue(0).HasComment("创建来源");
            builder.Property(p => p.CreateTime).HasComment("创建时间");
            builder.Property(p => p.EditTime).HasComment("编辑时间");
            builder.Property(p => p.UpdateTime).HasComment("更新时间");
            builder.Property(p => p.Deleted).HasDefaultValue(false).HasComment("删除");
            builder.Property(p => p.DisallowComment).HasDefaultValue(false).HasComment("禁止评论");
            builder.Property(p => p.Likes).HasDefaultValue(0).HasComment("赞同数");
            builder.Property(p => p.Status).HasDefaultValue(1).HasComment("状态");
            builder.Property(p => p.Password).HasMaxLength(200).HasDefaultValue("").HasComment("访问密码");
            builder.Property(p => p.Summary).HasComment("摘要");
            builder.Property(p => p.Template).HasMaxLength(500).HasComment("模板");
            builder.Property(p => p.Thumbnail).HasMaxLength(1000).HasDefaultValue("").HasComment("缩略图");
            builder.Property(p => p.TopPriority).HasDefaultValue(0).HasComment("优先级");
            builder.Property(p => p.Url).HasMaxLength(200).HasComment("链接");
            builder.Property(p => p.Visits).HasDefaultValue(0).HasComment("浏览量");
            builder.Property(p => p.MetaDescription).HasMaxLength(1000).HasComment("描述");
            builder.Property(p => p.MetaKeywords).HasMaxLength(500).HasComment("关键词");
            builder.Property(p => p.WordCount).HasDefaultValue(0).HasComment("字数");
            
            builder.HasIndex(p => p.Url).IsUnique();
            builder.HasIndex(p => p.Slug).IsUnique();
        }
    }
}
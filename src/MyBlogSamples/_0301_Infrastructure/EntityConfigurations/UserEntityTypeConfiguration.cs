using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.UserAggregate;

namespace MyBlog.Infrastructure.EntityConfigurations
{
    /// <summary>
    /// 用户实体类型配置
    /// </summary>
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasComment("主键");
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired().HasComment("名称");
            builder.Property(p => p.Nickname).HasMaxLength(30).IsUnicode().HasComment("昵称");
            builder.Property(p => p.Email).HasMaxLength(100).HasComment("邮箱");
            builder.Property(p => p.Tel).HasMaxLength(20).HasComment("手机号");
            builder.Property(p => p.IsAdmin).HasDefaultValue(false).HasComment("是否管理员");
            builder.Property(p => p.Password).HasMaxLength(200).HasComment("密码");
            builder.Property(p => p.Deleted).HasDefaultValue(false).HasComment("是否删除");
            builder.Property(p => p.CreateTime).HasComment("创建时间");
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
                a.Property(p => p.Country).HasMaxLength(50).IsUnicode().HasComment("国家");
                a.Property(p => p.City).HasMaxLength(50).IsUnicode().HasComment("城市");
                a.Property(p => p.Street).HasMaxLength(500).IsUnicode().HasComment("街道");
                a.Property(p => p.ZipCode).HasMaxLength(20).HasComment("邮编");
            });

            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.Tel).IsUnique();
        }
    }
}
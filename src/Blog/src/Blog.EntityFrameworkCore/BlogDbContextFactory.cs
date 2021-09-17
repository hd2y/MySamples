using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.EntityFrameworkCore
{
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var blogOptions = new BlogOptions();
            var connectionString = configuration.GetConnectionString("Blog");
            configuration.GetSection("Blog").Bind(blogOptions);
            var builder = blogOptions.DbType switch
            {
                DbType.SqlServer => new DbContextOptionsBuilder<BlogDbContext>()
                    .UseSqlServer(connectionString),
                DbType.MySQL => new DbContextOptionsBuilder<BlogDbContext>()
                    .UseMySql(connectionString, ServerVersion.Parse(blogOptions.ServerVersion)),
                DbType.PostgreSql => new DbContextOptionsBuilder<BlogDbContext>()
                    .UseNpgsql(connectionString),
                DbType.Oracle => new DbContextOptionsBuilder<BlogDbContext>()
                    .UseOracle(connectionString),
                _ => new DbContextOptionsBuilder<BlogDbContext>()
                    .UseSqlite(connectionString),
            };

            return new BlogDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Blog.HttpApi.Hosting/"))
                .AddJsonFile("appsettings.json", optional: false);
            
            return builder.Build();
        }
    }
}
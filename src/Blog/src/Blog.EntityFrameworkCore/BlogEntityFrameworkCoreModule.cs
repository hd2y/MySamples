using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.Oracle;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlogDomainModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpEntityFrameworkCoreOracleModule),
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule)
    )]
    public class BlogEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BlogDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also BlogMigrationsDbContextFactory for EF Core tooling. */

                var blogOptions = context.Services.GetRequiredService<IOptions<BlogOptions>>().Value;

                switch (blogOptions.DbType)
                {
                    case DbType.SqlServer:
                        options.UseSqlServer();
                        break;
                    case DbType.MySQL:
                        options.UseMySQL();
                        break;
                    case DbType.PostgreSql:
                        options.UseNpgsql();
                        break;
                    case DbType.Oracle:
                        options.UseOracle();
                        break;
                    case DbType.Sqlite:
                        options.UseSqlite();
                        break;
                    default:
                        options.UseSqlite();
                        break;
                }
            });
        }
    }
}
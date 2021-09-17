using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FreeSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace _210906_Autofac
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var db = new FreeSqlBuilder()
                .UseConnectionString(DataType.Sqlite, "Data Source=db1.db")
                .Build();
            var db1 = new FreeSqlBuilder()
                .UseConnectionString(DataType.Sqlite, "Data Source=db1.db")
                .Build<Db1>();
            var db2 = new FreeSqlBuilder()
                .UseConnectionString(DataType.Sqlite, "Data Source=db2.db")
                .Build<Db2>();
            builder.RegisterInstance(db).As<IFreeSql>();
            builder.RegisterInstance(db1).As<IFreeSql<Db1>>();
            builder.RegisterInstance(db2).As<IFreeSql<Db2>>();
            builder.RegisterType<TestService>().InstancePerLifetimeScope().PropertiesAutowired();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Autofac", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autofac v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }

    public class Db1
    {
    }

    public class Db2
    {
    }
}
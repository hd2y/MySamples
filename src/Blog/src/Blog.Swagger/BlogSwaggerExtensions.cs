using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Blog.Swagger
{
    public static class BlogSwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "我的接口啊",
                    Description = "接口描述"
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Blog.Domain.Shared.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Blog.Application.Contracts.xml"));
            });
        }

        public static void UseSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
            });
        }
    }
}
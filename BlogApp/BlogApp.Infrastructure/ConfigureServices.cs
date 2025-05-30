using AutoMapper;
using BlogApp.Domain.Repository;
using BlogApp.Infrastructure.Data;
using BlogApp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<BlogDBContext>(options =>

                options.UseSqlite(configuration.GetConnectionString("BlogDbContext") ??
                                  throw new InvalidOperationException("Connection string 'BlogDbContext' not found "))
            );

            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}

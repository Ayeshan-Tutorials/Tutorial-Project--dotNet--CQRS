using BlogApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}

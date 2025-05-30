using BlogApp.Domain.Entity;
using BlogApp.Domain.Repository;
using BlogApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _blogDbContext;

        public BlogRepository(BlogDBContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
           await _blogDbContext.Blogs.AddAsync(blog);
           await _blogDbContext.SaveChangesAsync();
           return blog;
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, blog.Id)
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.Author, blog.Author)
                );
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogDbContext.Blogs
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

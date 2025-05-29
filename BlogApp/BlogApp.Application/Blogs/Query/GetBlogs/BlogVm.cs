using BlogApp.Application.Common.Mappings;
using BlogApp.Domain.Entity;

namespace BlogApp.Application.Blogs.Query.GetBlogs
{
    public class BlogVm : IMapFrom<Blog>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}

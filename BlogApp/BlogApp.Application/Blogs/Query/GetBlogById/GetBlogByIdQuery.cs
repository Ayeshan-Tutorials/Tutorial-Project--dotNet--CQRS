using BlogApp.Application.Blogs.Query.GetBlogs;
using MediatR;

namespace BlogApp.Application.Blogs.Query.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}

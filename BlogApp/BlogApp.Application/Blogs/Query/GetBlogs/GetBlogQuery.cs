using MediatR;

namespace BlogApp.Application.Blogs.Query.GetBlogs
{
    public class GetBlogQuery : IRequest<List<BlogVm>>
    {

    }

    // New Way
    // public record GetBlogQuery : IRequest<List<BlogVm>>;

}

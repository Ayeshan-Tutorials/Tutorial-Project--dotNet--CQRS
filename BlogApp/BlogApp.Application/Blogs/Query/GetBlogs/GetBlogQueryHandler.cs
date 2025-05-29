using BlogApp.Domain.Repository;
using MediatR;

namespace BlogApp.Application.Blogs.Query.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();

            var blogList = blogs.Select( x => new BlogVm { Author =  x.Author, Name = x.Name, Description = x.Description }).ToList();

            return blogList;
        }
    }
}

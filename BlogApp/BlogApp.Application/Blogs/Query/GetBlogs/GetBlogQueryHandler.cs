using AutoMapper;
using BlogApp.Domain.Repository;
using MediatR;

namespace BlogApp.Application.Blogs.Query.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();

            var blogList = _mapper.Map<List<BlogVm>>(blogs);

            return blogList;
        }
    }
}

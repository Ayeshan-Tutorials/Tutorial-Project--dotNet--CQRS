using AutoMapper;
using BlogApp.Application.Blogs.Query.GetBlogs;
using BlogApp.Domain.Entity;
using BlogApp.Domain.Repository;
using MediatR;

namespace BlogApp.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper )
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog()
            {
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };

           var Result =  await _blogRepository.CreateAsync(blogEntity);
           return _mapper.Map<BlogVm>(Result);
        }
    }
}

using BlogApp.Domain.Entity;
using BlogApp.Domain.Repository;
using MediatR;

namespace BlogApp.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Author = request.Author,
                Description = request.Description
            };

            return await _blogRepository.UpdateAsync(request.Id, blogEntity);
        }
    }
}

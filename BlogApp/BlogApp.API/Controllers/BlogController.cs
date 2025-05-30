using BlogApp.Application.Blogs.Commands.CreateBlog;
using BlogApp.Application.Blogs.Commands.DeleteBlog;
using BlogApp.Application.Blogs.Commands.UpdateBlog;
using BlogApp.Application.Blogs.Query.GetBlogById;
using BlogApp.Application.Blogs.Query.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand blogCommand)
        {
            var createdBlog = await Mediator.Send(blogCommand);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand blogCommand)
        {
            if (id != blogCommand.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(blogCommand);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBlogCommand() { Id = id });
            return Ok();
        }

    }
}

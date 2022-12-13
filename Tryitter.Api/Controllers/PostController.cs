using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.DTOs;
using Tryitter.Api.Models;
using Tryitter.Api.Repository;

namespace Tryitter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return Ok(_postRepository.GetPosts());
        }

        [HttpGet("last")]
        public ActionResult<Post> GetLastPost(int id)
        {
            var post = _postRepository.GetLastPost(id);

            if (post is null)
            {
                return NotFound("Pessoa estudante não possui post.");
            }

            return Ok(post);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _postRepository.GetPostById(id);

            if (post is null)
            {
                return NotFound("Pessoa estudante não possui post.");
            }

            return Ok(post);
        }

        [HttpPost]
        public ActionResult<Post> AddPost([FromBody] PostInput postInput)
        {
            var post = new Post()
            {
                Description = postInput.Description,
                StudentId = postInput.StudentId
            };

            _postRepository.AddPost(post);

            return CreatedAtRoute("GetPostById", new { id = post.PostId }, post);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Post> UpdatePost(int id, [FromBody] PostInput postInput)
        {
            var post = _postRepository.GetPostById(id);

            if (post is null)
            {
                return NotFound("Post não encontrado.");
            }

            post.Description = postInput.Description;
            post.StudentId = postInput.StudentId;

            _postRepository.UpdatePost(post);

            return Ok(postInput);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Post> DeletePost(int id)
        {
            var post = _postRepository.GetPostById(id);

            if (post is null)
            {
                return NotFound("Post não encontrado.");
            }

            _postRepository.DeletePost(post);

            return NoContent();
        }

    }
}

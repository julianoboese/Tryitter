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
        [AllowAnonymous]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return Ok(_postRepository.GetPosts());
        }

        [HttpGet("last")]
        [Authorize]
        public ActionResult<Post> GetLastPost()
        {
            var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

            var post = _postRepository.GetLastPost(int.Parse(loggedStudentId));

            if (post is null)
            {
                return NotFound("Você ainda não fez nenhum post.");
            }

            return Ok(post);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        [AllowAnonymous]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _postRepository.GetPostById(id);

            if (post is null)
            {
                return NotFound("Post não encontrado.");
            }

            return Ok(post);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Post> AddPost([FromBody] PostInput postInput)
        {
            var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

            var post = new Post()
            {
                Description = postInput.Description,
                StudentId = int.Parse(loggedStudentId)
            };

            _postRepository.AddPost(post);

            return CreatedAtRoute("GetPostById", new { id = post.PostId }, post);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Post> UpdatePost(int id, [FromBody] PostInput postInput)
        {
            var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

            var post = _postRepository.GetPostById(id);

            if (post is null || post.StudentId.ToString() != loggedStudentId)
            {
                return Unauthorized("Você não pode editar este post.");
            }

            post.Description = postInput.Description;
            post.StudentId = int.Parse(loggedStudentId);

            _postRepository.UpdatePost(post);

            return Ok(postInput);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Post> DeletePost(int id)
        {
            var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
            var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

            var post = _postRepository.GetPostById(id);

            if (post is null || post.StudentId.ToString() != loggedStudentId)
            {
                return Unauthorized("Você não pode deletar este post.");
            }

            _postRepository.DeletePost(post);

            return NoContent();
        }

    }
}

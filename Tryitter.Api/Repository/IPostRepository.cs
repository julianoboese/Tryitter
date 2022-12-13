using Tryitter.Api.Models;

namespace Tryitter.Api.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        Post? GetPostById(int postId);
        Post? GetLastPost(int postId);
        Post AddPost(Post post);
        Post UpdatePost(Post post);
        Post DeletePost(Post post);
    }
}
using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface IPostRepository
    {
        Post GetPostById(int postId);
        Post GetLastPostById(int studentId);
        IEnumerable<Post> GetPosts();
        bool AddPost(Post post);
        bool UpdatePost(Post post, int postId);
        bool DeletePost(Post post);
    }
}
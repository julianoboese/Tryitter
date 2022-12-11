using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface IPostRepository
    {
        Post GetPostById(int postId);
        Post GetLastPostById(int studentId);
        Post GetPosts();
        Post AddPost(Post post);
        Post UpdatePost(Post post, int id);
        Post DeletePost(int id);
    }
}
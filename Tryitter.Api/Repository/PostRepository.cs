using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class PostRepository : IPostRepository
{
  private readonly ITryitterContext _context;

  public PostRepository(ITryitterContext context)
  {
    _context = context;
  }

    public Post AddPost(Post post)
    {
        throw new NotImplementedException();
    }

    public Post DeletePost(int id)
    {
        throw new NotImplementedException();
    }

    public Post GetLastPostById(int studentId)
    {
        throw new NotImplementedException();
    }

    public Post GetPostById(int postId)
    {
        throw new NotImplementedException();
    }

    public Post GetPosts()
    {
        throw new NotImplementedException();
    }

    public Post UpdatePost(Post post, int id)
    {
        throw new NotImplementedException();
    }
}
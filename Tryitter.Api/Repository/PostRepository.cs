using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class PostRepository : IPostRepository
{
  private readonly ITryitterContext _context;

  public PostRepository(ITryitterContext context)
  {
    _context = context;
  }

    public bool AddPost(Post post)
    {
        var postById = GetPostById(post.PostId);

        if (postById != null) return false;

        _context.Posts.Add(post);

        return true;
    }

    public bool DeletePost(Post post)
    {
        var postById = GetPostById(post.PostId);

        if (postById is null) return false;

        _context.Posts.Remove(post);

        return true;
    }

    public Post GetLastPostById(int studentId)
    {
        throw new NotImplementedException();
    }

    public Post GetPostById(int postId)
    {
        return _context.Posts.Find(postId)!;
    }

    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts.AsEnumerable();
    }

    public bool UpdatePost(Post post, int postId)
    {
        var postById = GetPostById(postId);

        if (postById is null) return false;

        _context.Posts.Update(post);

        return true;
    }

  /*Post IPostRepository.AddPost(Post post)
  {
    throw new NotImplementedException();
  }*/
}
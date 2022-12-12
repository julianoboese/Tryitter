using Tryitter.Api.Models;

namespace Tryitter.Api.Repository;

public class PostRepository : IPostRepository
{
  private readonly ITryitterContext _context;

  public PostRepository(ITryitterContext context)
  {
    _context = context;
  }

    public Post AddPost(Post post)
    {
        _context.Posts.Add(post);

        _context.SaveChanges();

        return post;
    }

    public Post DeletePost(Post post)
    {
        _context.Posts.Remove(post);

        _context.SaveChanges();

        return post;
    }

    public Post GetLastPostById(int studentId)
    {
        /* var posts = _context.Posts.Where(s => s.StudentId == studentId); */
        throw new NotImplementedException();
    }

    public Post? GetPostById(int postId)
    {
        return _context.Posts.Find(postId);
    }

    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts;
    }

    public Post UpdatePost(Post post)
    {
        _context.Posts.Update(post);

        _context.SaveChanges();

        return post;
    }
}
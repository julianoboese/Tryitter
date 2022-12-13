using Microsoft.Extensions.Hosting;
using Tryitter.Api.Models;

namespace Tryitter.Api.Repository;

public class PostRepository : IPostRepository
{
    private readonly ITryitterContext _context;

    public PostRepository(ITryitterContext context)
    {
        _context = context;
    }

    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts;
    }

    public Post GetLastPost(int studentId)
    {
        var post = _context.Posts.OrderByDescending(p => p.PostId).FirstOrDefault(s => s.StudentId == studentId);

        return post;
    }

    public Post? GetPostById(int postId)
    {
        return _context.Posts.Find(postId);
    }

    public Post AddPost(Post post)
    {
        _context.Posts.Add(post);

        _context.SaveChanges();

        return post;
    }

    public Post UpdatePost(Post post)
    {
        _context.Posts.Update(post);

        _context.SaveChanges();

        return post;
    }

    public Post DeletePost(Post post)
    {
        _context.Posts.Remove(post);

        _context.SaveChanges();

        return post;
    }
}
using Microsoft.EntityFrameworkCore;
using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
  public interface ITryitterApiContext
  {
    public DbSet<Module> Module { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Student> Student { get; set; }

    public int SaveChanges();
  }
}

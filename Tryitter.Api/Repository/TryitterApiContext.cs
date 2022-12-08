using Microsoft.EntityFrameworkCore;
using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class TryitterApiContext : DbContext, ITryitterApiContext
{
  public TryitterApiContext(DbContextOptions<TryitterApiContext> options) : base(options) { }

  public TryitterApiContext() { }

  public virtual DbSet<Student> Student { get; set; } = default!;
  public virtual DbSet<Post> Post { get; set; } = default!;
  public virtual DbSet<Module> Module { get; set; } = default!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=TryitterDB;User=sa;Password=Password123!");
    }
  }
}
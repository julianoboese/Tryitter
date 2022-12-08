using Microsoft.EntityFrameworkCore;
using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class TryitterContext : DbContext, ITryitterContext
{
    public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

    public TryitterContext() { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Module> Modules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"
                 Server=127.0.0.1;
                 Database=TryitterDB;
                 User=sa;
                 Password=Password123!;
             ");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Module)
            .WithMany(m => m.Students)
            .HasForeignKey(s => s.ModuleId);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Student)
            .WithMany(s => s.Posts)
            .HasForeignKey(p => p.PostId);
    }
}
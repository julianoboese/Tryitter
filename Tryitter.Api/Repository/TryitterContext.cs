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
        modelBuilder.Entity<Module>().HasData(
            new Module { ModuleId = 1, Name = "Fundamentos" },
            new Module { ModuleId = 2, Name = "Front-end" },
            new Module { ModuleId = 3, Name = "Back-end" },
            new Module { ModuleId = 4, Name = "Ciência da Computação" }
        );

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Module)
            .WithMany()
            .HasForeignKey(s => s.ModuleId);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Student)
            .WithMany()
            .HasForeignKey(p => p.PostId);
    }
}
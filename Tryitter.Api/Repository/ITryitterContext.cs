using Microsoft.EntityFrameworkCore;
using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface ITryitterContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Student> Students { get; set; }
        public int SaveChanges();
    }
}

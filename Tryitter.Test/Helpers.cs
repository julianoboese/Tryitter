using Microsoft.EntityFrameworkCore;
using Tryitter.Api.Models;
using Tryitter.Api.Repository;

namespace Tryitter.Test
{
    public static class Helpers
    {
        public static TryitterContext GetContextInstanceForTests(string inMemoryDbName)
        {
            var contextOptions = new DbContextOptionsBuilder<TryitterContext>()
                .UseInMemoryDatabase(inMemoryDbName)
                .Options;
            var context = new TryitterContext(contextOptions);

            context.Modules.AddRange(
                GetModulesForTests()
            );

            context.Students.AddRange(
                GetStudentsForTests()
            );
            
            context.Posts.AddRange(
                GetPostsForTests()
            );
            context.SaveChanges();
            return context;
        }

        public static List<Module> GetModulesForTests() =>
            new() {
                new Module { ModuleId = 1, Name = "Fundamentos" },
                new Module { ModuleId = 2, Name = "Front-end" },
                new Module { ModuleId = 3, Name = "Back-end" },
                new Module { ModuleId = 4, Name = "Ciência da Computação" }
            };

        public static List<Student> GetStudentsForTests() =>
            new() {
                new Student
                {
                    StudentId = 1,
                    Name = "Fulano Silva",
                    Email = "fulano@email.com",
                    Password = "password",
                    ModuleId = 1,
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Beltrano Souza",
                    Email = "beltrano@email.com",
                    Password = "123456",
                    ModuleId = 3,
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Ciclano Cardoso",
                    Email = "ciclano@email.com",
                    Password = "12345678",
                    ModuleId = 4,
                },
            };


        public static List<Post> GetPostsForTests() =>
            new() {
                new Post
                {
                    PostId = 1,
                    Description = "Primeiro post de teste.",
                    StudentId = 2,
                },
                new Post
                {
                    PostId = 2,
                    Description = "Segundo post de teste.",
                    StudentId = 1,
                },
                new Post
                {
                    PostId = 3,
                    Description = "Terceiro post de teste.",
                    StudentId = 3,
                },
                new Post
                {
                    PostId = 4,
                    Description = "Quarto post de teste.",
                    StudentId = 2,
                },
            };
    }
}

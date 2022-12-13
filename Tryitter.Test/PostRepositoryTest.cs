using FluentAssertions;
using System.Threading.Channels;
using Tryitter.Api.DTOs;
using Tryitter.Api.Models;
using Tryitter.Api.Repository;

namespace Tryitter.Test
{
    public class PostRepositoryTest
    {
        [Theory]
        [MemberData(nameof(PostsData))]
        public void TestGetPosts(TryitterContext context, List<Post> expectedPosts)
        {
            // Arrange
            var repository = new PostRepository(context);

            // Act
            var posts = repository.GetPosts();

            // Assert
            posts.Should().BeEquivalentTo(expectedPosts);
        }

        public readonly static TheoryData<TryitterContext, List<Post>> PostsData = new()
        {
          {
              Helpers.GetContextInstanceForTests("PostsData"), new()
              {
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
              }
          }
        
        };

        [Theory]
        [MemberData(nameof(GetPostByIdData))]
        public void TestGetPostById(TryitterContext context, int id, Post expectedPost)
        {
            // Arrange
              var repository = new PostRepository(context);

              // Act
              var post = repository.GetPostById(id);

              // Assert
              post.Should().BeEquivalentTo(expectedPost);
        }

        public readonly static TheoryData<TryitterContext, int, Post> PostsByIdData = new()
        {
          {
              Helpers.GetContextInstanceForTests("GetPostByIdData"), 1,
              new Post
              {
                PostId = 1,
                Description = "Primeiro post de teste.",
                StudentId = 2,
              } 
          }
        };
      // teste
    }
}
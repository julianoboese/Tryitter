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
        [MemberData(nameof(TestPostsData))]
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
        [MemberData(nameof(TestGetPostByIdData))]
        public void TestGetPostById(TryitterContext context, int id, Post expectedPost)
        {
            // Arrange
              var repository = new PostRepository(context);

              // Act
              var post = repository.GetPostById(id);

              // Assert
              post.Should().BeEquivalentTo(expectedPost);
        }

        public readonly static TheoryData<TryitterContext, int, Post> TestGetPostByIdData = new()
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
      
      [Theory]
      [MemberData(nameof(TestAddPostData))]
      public void TestAddPost(TryitterContext context, Post post, List<Post> expectedPost)
      {
          // Arrange
          var repository = new PostRepository(context);

          // Act
          repository.AddPost(post) ;
          var posts = repository.GetPosts();

          // Assert
          posts.Should().BeEquivalentTo(expectedPost);
      }

      public readonly static TheoryData<TryitterContext, Post, List<Post>> TestAddPostData = new()
      {
          {
              Helpers.GetContextInstanceForTests("TestAddPost"),
              new Post
                  {
                      Description = "Segundo post de teste.",
                      StudentId = 2,
                  },
              new()
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
      [MemberData(nameof(TestUpdatePostData))]
      public void TestUpdatePost(TryitterContext context, int id, Post postChanges, List<Post> expectedPost)
      {
          // Arrange
          var repository = new PostRepository(context);

          var post = repository.GetPostById(id);
          post.Description = postChanges.Description;

          // Act
          repository.UpdatePost(post);
          var posts = repository.GetPosts();

          // Assert
          posts.Should().BeEquivalentTo(expectedPost);
      }

      public readonly static TheoryData<TryitterContext, int, Post, List<Post>> TestUpdatePostData = new()
      {
          {
              Helpers.GetContextInstanceForTests("TestUpdatePost"),
              2,
              new Post
                  {
                      Description = "Post editado de teste.",
                      StudentId = 2,
                  },
              new()
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
      [MemberData(nameof(TestDeletePosttData))]
      public void TestDeletePost(TryitterContext context, int id, List<Post> expectedPost)
      {
          // Arrange
          var repository = new PostRepository(context);

          var post = repository.GetPostById(id);

          // Act
          repository.DeletePost(post);
          var posts = repository.GetPosts();

          // Assert
          posts.Should().BeEquivalentTo(expectedPost);
      }

      public readonly static TheoryData<TryitterContext, int, List<Post>> TestDeletePostData = new()
      {
          {
              Helpers.GetContextInstanceForTests("TestDeletePost"),
              1,
              new()
              {
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
    }
}
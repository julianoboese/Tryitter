using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
  public interface ITryitterApiRepository
  {
    Student GetStudentById(int studentId);
    Student GetStudents();
    Student GetStudentByName(string name);
    Student AddStudent(Student student);
    Student UpdateStudent(Student student, int id);
    Student DeleteStudent(int id);

    Post GetPostById(int postId);
    Post GetLastPostById(int studentId);
    Post GetPosts();
    Post AddPost(Post post);
    Post UpdatePost(Post post, int id);
    Post DeletePost(int id);
  }
}
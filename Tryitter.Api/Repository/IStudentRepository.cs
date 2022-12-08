using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);
        Student GetStudents();
        Student GetStudentByName(string name);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student, int id);
        Student DeleteStudent(int id);
    }
}
using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetStudents();
        Student GetStudentByName(string name);
        bool AddStudent(Student student);
        bool UpdateStudent(Student student, int studentId);
        bool DeleteStudent(Student student);
    }
}
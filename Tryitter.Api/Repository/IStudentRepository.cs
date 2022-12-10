using Tryitter.Api.DTOs;
using Tryitter.Api.Models;

namespace tryitter_api.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        Student GetStudentByEmailAndPassword(AuthInput authInput);
        IEnumerable<Student> GetStudentsByName(string name);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(Student student);
    }
}
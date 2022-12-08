using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class StudentRepository : IStudentRepository
{
  private readonly ITryitterContext _context;

  public StudentRepository(ITryitterContext context)
  {
    _context = context;
  }

    public Student AddStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public Student DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public Student GetStudentById(int studentId)
    {
        throw new NotImplementedException();
    }

    public Student GetStudentByName(string name)
    {
        throw new NotImplementedException();
    }

    public Student GetStudents()
    {
        throw new NotImplementedException();
    }

    public Student UpdateStudent(Student student, int id)
    {
        throw new NotImplementedException();
    }
}
using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class StudentRepository : IStudentRepository
{
  private readonly ITryitterContext _context;

  public StudentRepository(ITryitterContext context)
  {
    _context = context;
  }

    public bool AddStudent(Student student)
    {
        var studentById = GetStudentById(student.StudentId);

        if (studentById != null) return false;

        _context.Students.Add(student);

        return true;
    }

    public bool DeleteStudent(Student student)
    {
        var studentById = GetStudentById(student.StudentId);

        if (studentById is null) return false;

        _context.Students.Remove(student);

        return true;
    }

    public Student GetStudentById(int studentId)
    {
        return _context.Students.Find(studentId)!;
    }

    public Student GetStudentByName(string name)
    {
        return _context.Students.Find(name)!;
    }

    public IEnumerable<Student> GetStudents()
    {
        return _context.Students.AsEnumerable();
    }

    public bool UpdateStudent(Student student, int studentId)
    {
        var studentById = GetStudentById(studentId);

        if (studentById is null) return false;

        _context.Students.Update(student);

        return true;
    }
}
using Tryitter.Api.DTOs;
using Tryitter.Api.Models;

namespace tryitter_api.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ITryitterContext _context;

    public StudentRepository(ITryitterContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetStudents()
    {
        return _context.Students;
    }

    public Student GetStudentById(int studentId)
    {
        return _context.Students.Find(studentId)!;
    }

    public Student GetStudentByEmailAndPassword(AuthInput authInput)
    {
        return _context.Students.First(s => s.Email == authInput.Email && s.Password == authInput.Password);
    }

    public IEnumerable<Student> GetStudentsByName(string name)
    {
        return _context.Students.Where(s => s.Name.Contains(name));
    }

    public Student AddStudent(Student student)
    {
        _context.Students.Add(student);

        _context.SaveChanges();

        return student;
    }

    public Student UpdateStudent(Student student)
    {
        _context.Students.Update(student);

        _context.SaveChanges();

        return student;
    }
    public Student DeleteStudent(Student student)
    {
        _context.Students.Remove(student);

        _context.SaveChanges();

        return student;
    }
}
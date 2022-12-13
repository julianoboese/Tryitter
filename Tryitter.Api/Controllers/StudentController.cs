using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.DTOs;
using Tryitter.Api.Models;
using Tryitter.Api.Repository;

namespace Tryitter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetStudents([FromQuery] string? name)
    {
        IEnumerable<Student> students;

        if (string.IsNullOrWhiteSpace(name))
        {
            students = _studentRepository.GetStudents();
        }
        else
        {
            students = _studentRepository.GetStudentsByName(name);
        }

        if (!students.Any())
        {
            return NotFound("Nenhuma pessoa estudante encontrada.");
        }

        return Ok(students);
    }

    [HttpGet("{id}", Name = "GetStudentById")]
    public ActionResult<Student> GetStudentById(int id)
    {
        var student = _studentRepository.GetStudentById(id);

        if (student is null)
        {
            return NotFound("Pessoa estudante não encontrada.");
        }

        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> AddStudent([FromBody] StudentInput studentInput)
    {
        var student = new Student()
        {
            Name = studentInput.Name,
            Email = studentInput.Email,
            Password = studentInput.Password,
            ModuleId = studentInput.ModuleId
        };

        _studentRepository.AddStudent(student);

        return CreatedAtRoute("GetStudentById", new { id = student.StudentId }, student);
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Student> UpdateStudent(int id, [FromBody] StudentInput studentInput)
    {
        var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
        var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

        var student = _studentRepository.GetStudentById(id);

        if (student is null || student.StudentId.ToString() != loggedStudentId)
        {
            return Unauthorized("Você não pode editar esta pessoa estudante.");
        }

        student.Name = studentInput.Name;
        student.Email = studentInput.Email;
        student.Password = studentInput.Password;
        student.ModuleId = studentInput.ModuleId;

        _studentRepository.UpdateStudent(student);

        return Ok(studentInput);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Student> DeleteStudent(int id)
    {
        var student = _studentRepository.GetStudentById(id);

        if (student is null)
        {
            return NotFound("Pessoa estudante não encontrada.");
        }

        _studentRepository.DeleteStudent(student);

        return NoContent();
    }
}
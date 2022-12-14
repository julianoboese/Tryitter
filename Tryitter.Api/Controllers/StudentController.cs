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
    [AllowAnonymous]
    public ActionResult<IEnumerable<StudentOutput>> GetStudents([FromQuery] string? name)
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

        var studentOutputList = new List<StudentOutput>();

        foreach (var student in students)
        {
            var studentOutput = new StudentOutput()
            {
                StudentId = student.StudentId,
                Name= student.Name,
                Email= student.Email,
                ModuleId= student.ModuleId,
            };

            studentOutputList.Add(studentOutput);
        }

        return Ok(studentOutputList);
    }

    [HttpGet("{id}", Name = "GetStudentById")]
    [AllowAnonymous]
    public ActionResult<StudentOutput> GetStudentById(int id)
    {
        var student = _studentRepository.GetStudentById(id);

        if (student is null)
        {
            return NotFound("Pessoa estudante não encontrada.");
        }

        var studentOutput = new StudentOutput()
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Email = student.Email,
            ModuleId = student.ModuleId,
        };

        return Ok(studentOutput);
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult<StudentOutput> AddStudent([FromBody] StudentInput studentInput)
    {
        var student = new Student()
        {
            Name = studentInput.Name,
            Email = studentInput.Email,
            Password = studentInput.Password,
            ModuleId = studentInput.ModuleId
        };

        _studentRepository.AddStudent(student);

        var studentOutput = new StudentOutput()
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Email = student.Email,
            ModuleId = student.ModuleId,
        };

        return CreatedAtRoute("GetStudentById", new { id = studentOutput.StudentId }, studentOutput);
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<StudentOutput> UpdateStudent(int id, [FromBody] StudentInput studentInput)
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

        var studentOutput = new StudentOutput()
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Email = student.Email,
            ModuleId = student.ModuleId,
        };

        return Ok(studentOutput);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<StudentOutput> DeleteStudent(int id)
    {
        var loggedStudent = User.Identity as System.Security.Claims.ClaimsIdentity;
        var loggedStudentId = loggedStudent!.FindFirst("StudentId").Value;

        var student = _studentRepository.GetStudentById(id);

        if (student is null || student.StudentId.ToString() != loggedStudentId)
        {
            return Unauthorized("Você não pode deletar esta pessoa estudante.");
        }

        _studentRepository.DeleteStudent(student);

        return NoContent();
    }
}
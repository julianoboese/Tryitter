using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.DTOs;
using Tryitter.Api.Services;
using Tryitter.Api.ViewModels;
using Tryitter.Api.Repository;

namespace Tryitter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public AuthController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public ActionResult<AuthOutput> Authenticate([FromBody] AuthInput authInput)
        {
            AuthOutput authOutput = new();

            try
            {
                var student = _studentRepository.GetStudentByEmailAndPassword(authInput);

                if (student == null)
                {
                    return NotFound("Dados incorretos.");
                }

                student.Password = string.Empty;

                authOutput.Student = student;
                authOutput.Token = new TokenGenerator().Generate(student);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return authOutput;
        }
    }
}

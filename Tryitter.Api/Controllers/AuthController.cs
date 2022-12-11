using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.DTOs;
using Tryitter.Api.Services;
using Tryitter.Api.ViewModels;
using tryitter_api.Repository;

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
                    return NotFound("Pessoa estudante não encontrada.");
                }

                authOutput.Student = student;
                authOutput.Student.Password = string.Empty;
                authOutput.Token = new TokenGenerator().Generate();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return authOutput;
        }
    }
}

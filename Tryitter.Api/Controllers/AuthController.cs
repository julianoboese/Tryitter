using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.Models;
using Tryitter.Api.Services;
using Tryitter.Api.ViewModels;

namespace Tryitter.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<StudentViewModel> Authenticate([FromBody] Student student)
        {
            StudentViewModel studentViewModel = new();

            try
            {
                //userViewModel.Student = new StudentRepository().Get(student);

                if (studentViewModel.Student == null)
                {
                    return NotFound("Student not found!");
                }

                studentViewModel.Token = new TokenGenerator().Generate();

                studentViewModel.Student.Password = string.Empty;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return studentViewModel;
        }
    }
}

using HB.Api.Models;
using HB.Core.Models;
using HB.Core.UseCases.User.GetAllUsers;
using HB.Core.UseCases.User.RegisterUser;
using HB.Storage;
using Microsoft.AspNetCore.Mvc;

namespace HB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(nameof(GetAllUsers))]
        [ProducesResponseType(200, Type = typeof(Models.User[]))]
        public async Task<IEnumerable<Models.User>> GetAllUsers(
            [FromServices] IGetAllUsersUseCase useCase,
            CancellationToken ct)
        {
            var list = await useCase.Execute(ct);
            return list.Select(t => new Models.User
            {
                UserId = t.UserId,
                Name = t.Name,
                SurName = t.Surname,
                Mail = t.Email
            });
        }

        [ProducesResponseType(201)]
        [HttpPost(nameof(RegisterUser))]
        public async Task<IActionResult> RegisterUser(
            [FromBody] Models.User user,
            [FromServices] IRegisterUserUseCase useCase,
            CancellationToken ct)
        {
            await useCase.RegisterUser(user.Name, user.SurName, user.Mail, ct);
            return Ok(new Models.User
            {
                UserId = user.UserId,
                Name = user.Name,
                SurName = user.SurName,
                Mail = user.Mail
            });
        }
    }
}

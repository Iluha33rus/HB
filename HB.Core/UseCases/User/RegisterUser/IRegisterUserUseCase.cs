using HB.Core.Models;

namespace HB.Core.UseCases.User.RegisterUser
{
    public interface IRegisterUserUseCase
    {
        public Task<Models.User> RegisterUser(string userName, string userSurname, string userEmail, CancellationToken ct);

    }
}

using HB.Core.GuidFactory;
using HB.Core.MomentFactory;
using HB.Storage;
using Microsoft.EntityFrameworkCore;
namespace HB.Core.UseCases.User.RegisterUser
{
    public class RegisterUserUseCase(HwContext dbContext, IGuidFactory guidFactory, IMomentFactory momentFactory) : IRegisterUserUseCase
    {
        private readonly HwContext dbContext = dbContext;
        private readonly IGuidFactory guidFactory = guidFactory;
        private readonly IMomentFactory momentFactory = momentFactory;

        public async Task<Models.User> RegisterUser(string userName, string userSurname, string userEmail, CancellationToken ct)
        {
            var userId = guidFactory.Create();

            await dbContext.Users.AddAsync(new Storage.User
            {
                UserId = userId,
                RegisteredAt = momentFactory.Now(),
                Name = userName,
                Surname = userSurname,
                Email = userEmail
            }, ct);
            await dbContext.SaveChangesAsync(ct);

            return await dbContext.Users
                .Where(f => f.UserId == userId)
                .Select(t => new Models.User
                {
                    UserId = t.UserId,
                    RegisteredAt = t.RegisteredAt,
                    Name = t.Name,
                    Surname = t.Surname,
                    Email = t.Email
                }).FirstAsync(ct);
        }
    }
}

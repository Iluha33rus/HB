using HB.Storage;
using Microsoft.EntityFrameworkCore;

namespace HB.Core.UseCases.User.GetAllUsers
{
    public class GetAllUsersUseCase(HwContext dbContext) : IGetAllUsersUseCase
    {
        private readonly HwContext dbContext = dbContext;

        public async Task<IEnumerable<Models.User>> Execute(
            CancellationToken ct) =>
            await dbContext.Users
            .Select(t => new Models.User
            {
                UserId = t.UserId,
                RegisteredAt = t.RegisteredAt,
                Name = t.Name,
                Surname = t.Surname,
                Email = t.Email
            }).ToArrayAsync(ct);
    }
}

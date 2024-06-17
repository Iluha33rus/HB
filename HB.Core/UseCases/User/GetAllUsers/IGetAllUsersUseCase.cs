using HB.Core.Models;
using HB.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Core.UseCases.User.GetAllUsers
{
    public interface IGetAllUsersUseCase
    {
        Task<IEnumerable<Models.User>> Execute(CancellationToken ct);
    }
}

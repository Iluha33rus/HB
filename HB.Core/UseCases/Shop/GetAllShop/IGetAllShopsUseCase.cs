using HB.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Core.UseCases.Shop.GetAllShop
{
    public interface IGetAllShopsUseCase
    {
        Task<IEnumerable<Models.Shop>> Execute(CancellationToken cancellationToken);
    }
    public class GetAllShopsUseCase(HwContext dbContext) : IGetAllShopsUseCase
    {
        private readonly HwContext dbContext = dbContext;

        public async Task<IEnumerable<Models.Shop>> Execute(CancellationToken cancellationToken)
        {
            return await dbContext.Shops
                .Select(t => new Models.Shop
                {
                    ShopId = t.ShopId,
                    RegisteredAt = t.RegisteredAt,
                    Name = t.Name,
                    Description = t.Description,
                    UserId = t.UserId,
                }).ToArrayAsync(cancellationToken);
        }
    }
}

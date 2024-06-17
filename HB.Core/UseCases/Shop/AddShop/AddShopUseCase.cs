using HB.Core.GuidFactory;
using HB.Core.MomentFactory;
using HB.Storage;
using Microsoft.EntityFrameworkCore;

namespace HB.Core.UseCases.Shop.AddShop
{
    public class AddShopUseCase(HwContext dbContext, IGuidFactory guidFactory, IMomentFactory momentFactory) : IAddShopUseCase
    {
        private readonly HwContext dbContext = dbContext;
        private readonly IGuidFactory guidFactory = guidFactory;
        private readonly IMomentFactory momentFactory = momentFactory;
        public async Task<Models.Shop> RegisterShop(string name, string description, Guid userId, CancellationToken ct)
        {
            var shopId = guidFactory.Create();

            await dbContext.Shops.AddAsync(new Storage.Shop
            {
                ShopId = shopId,
                RegisteredAt = momentFactory.Now(),
                Name = name,
                Description = description,
                UserId = userId,
            }, ct);

            await dbContext.SaveChangesAsync(ct);

            return await dbContext.Shops
                .Where(f => f.ShopId == shopId)
                .Select(t => new Models.Shop
                {
                    ShopId = t.ShopId,
                    RegisteredAt = t.RegisteredAt,
                    Name = t.Name,
                    Description = t.Description,
                    UserId = userId,
                }).FirstAsync(ct);
        }
    }
}

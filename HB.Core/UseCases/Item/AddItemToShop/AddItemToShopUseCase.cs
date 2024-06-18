using HB.Core.GuidFactory;
using HB.Core.MomentFactory;
using HB.Storage;
using Microsoft.EntityFrameworkCore;

namespace HB.Core.UseCases.Item.AddItemToShop
{
    public class AddItemToShopUseCase(HwContext dbContext, IGuidFactory guidFactory, IMomentFactory momentFactory) : IAddItemToShopUseCase
    {
        //TODO: сделать реализацию IEnumerable<Item>
        private readonly HwContext dbContext = dbContext;
        private readonly IGuidFactory guidFactory = guidFactory;
        private readonly IMomentFactory momentFactory = momentFactory;

        public async Task<Models.Item> Execute(string name, string description, decimal price, bool isHave, int countItem, Guid shopId, CancellationToken cancellationToken)
        {
            var itemId = guidFactory.Create();
            var itemAdded = momentFactory.Now();
            await dbContext.Items.AddAsync(new HB.Storage.Item
            {
                ItemId = itemId,
                Name = name,
                Description = description,
                Price = price,
                IsHave = isHave,
                CountItem = countItem,
                ShopId = shopId,
                ItemAdded = itemAdded
            }, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return await dbContext.Items
                .Where(f => f.ItemId == itemId)
                .Select(t => new Models.Item
                {
                    ItemId = t.ItemId,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price,
                    IsHave = t.IsHave,
                    Count = t.CountItem,
                    ShopId = t.ShopId,
                    ItemAdded = t.ItemAdded
                }).FirstAsync(cancellationToken);


        }
    }
}

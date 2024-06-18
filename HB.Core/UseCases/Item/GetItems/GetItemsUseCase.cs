
using HB.Storage;
using Microsoft.EntityFrameworkCore;

namespace HB.Core.UseCases.Item.GetItems
{
    public class GetItemsUseCase(
        HwContext dbContext) : IGetItemsUseCase
    {
        private readonly HwContext dbContext = dbContext;

        public async Task<IEnumerable<Models.Item>> Execute(string shopName, CancellationToken cancellationToken)
        {
            /*if (shopName == null)
            {
                return await dbContext.Items
               .Select(t => new Models.Item
               {
                   ItemId = t.ItemId,
                   Name = t.Name,
                   Description = t.Description,
                   Price = t.Price,
                   IsHave = t.IsHave,
                   Count = t.CountItem,
                   ItemAdded = t.ItemAdded,
                   ShopId = t.ShopId,
               }).ToArrayAsync(cancellationToken);
            }

            var shop = await dbContext.Shops.Where(t => t.Name == shopName).FirstAsync(cancellationToken);

            return await dbContext.Items
                .Where(t => t.ShopId == shop.ShopId)
                .Select(t => new Models.Item
                {
                    ItemId = t.ItemId,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price,
                    IsHave = t.IsHave,
                    Count = t.CountItem,
                    ItemAdded = t.ItemAdded,
                    ShopId = t.ShopId,
                    ShopName = 
                }).ToArrayAsync(cancellationToken);*/

            if (string.IsNullOrWhiteSpace(shopName))
            {
                await dbContext.Items.Join()

            }

        }
    }
}





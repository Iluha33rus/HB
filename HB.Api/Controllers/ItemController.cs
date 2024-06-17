using HB.Core.UseCases.Item.AddItemToShop;
using HB.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpGet(nameof(GetAllItems))]
        [ProducesResponseType(200, Type = typeof(Models.Item[]))]
        public async Task<IActionResult> GetAllItems(
            HwContext dbcontext,
            CancellationToken ct)
        {
            var list = await dbcontext.Items.ToArrayAsync(ct);

            var result = (list
                 .Select(f => new Models.Item
                 {
                     Name = f.Name,
                     Description = f.Description,
                     Price = f.Price,
                     IsHave = f.IsHave,
                     CountItem = f.CountItem,
                     ShopId = f.ShopId,

                 }));
            return Ok(result);
        }
        [HttpPost(nameof(AddItemToShop))]
        public async Task<IActionResult> AddItemToShop(
            [FromBody] Models.Item item,
            [FromServices] IAddItemToShopUseCase useCase,
            CancellationToken ct
            )
        {
            await useCase.Execute(item.Name, item.Description, item.Price, item.IsHave, item.CountItem, item.ShopId, ct);
            return Ok(new Models.Item
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                IsHave = item.IsHave,
                CountItem = item.CountItem,
                ShopId = item.ShopId,
            });
        }
    }
}

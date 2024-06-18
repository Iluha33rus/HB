using HB.Api.Models;
using HB.Core.UseCases.Item.AddItemToShop;
using HB.Core.UseCases.Item.GetItems;
using Microsoft.AspNetCore.Mvc;

namespace HB.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        //TODO: сделать выборку по наименованию товара, а так же добавить категории товаров
        [HttpGet(nameof(GetAllItems))]
        [ProducesResponseType(200, Type = typeof(ResponseItem[]))]
        public async Task<IEnumerable<ResponseItem>> GetAllItems(
            string? shopName,
            [FromServices] IGetItemsUseCase useCase,
            CancellationToken ct)
        {
            var list = await useCase.Execute(shopName,ct);

            return list.Select(t => new ResponseItem
            {
                Name = t.Name,
                Description = t.Description,
                Price = t.Price,
                IsHave = t.IsHave,
                Count = t.Count,
                ShopName = t.ShopName,
            });
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

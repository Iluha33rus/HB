using HB.Core.UseCases.Shop.AddShop;
using HB.Core.UseCases.Shop.GetAllShop;
using Microsoft.AspNetCore.Mvc;

namespace HB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpGet(nameof(GetAllShops))]
        [ProducesResponseType(200, Type = typeof(Models.Shop[]))]
        public async Task<IEnumerable<Models.Shop>> GetAllShops(
          [FromServices] IGetAllShopsUseCase useCase,
          CancellationToken ct)
        {
            var list = await useCase.Execute(ct);
            return list.Select(t => new Models.Shop
            {
                ShopId = t.ShopId,
                Name = t.Name,
                UserId = t.UserId,
                Description = t.Description,
                RegisteredAt = t.RegisteredAt,

            });
        }

        [ProducesResponseType(201)]
        [HttpPost(nameof(RegisterShop))]
        public async Task<IActionResult> RegisterShop(
           [FromBody] Models.Shop shop,
           [FromServices] IAddShopUseCase useCase,
           CancellationToken ct)
        {
            await useCase.RegisterShop(shop.Name, shop.Description, shop.UserId, ct);
            return Ok(new Models.Shop
            {
                ShopId = shop.ShopId,
                Name = shop.Name,
                Description = shop.Description,
                RegisteredAt = shop.RegisteredAt,
                UserId = shop.UserId
            });
        }
    }
}

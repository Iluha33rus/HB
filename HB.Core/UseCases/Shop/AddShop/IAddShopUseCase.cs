using HB.Core.Models;

namespace HB.Core.UseCases.Shop.AddShop
{
    public interface IAddShopUseCase
    {
        Task<Models.Shop> RegisterShop(string name, string description, Guid userId, CancellationToken ct);
    }
}

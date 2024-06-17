namespace HB.Core.UseCases.Item.AddItemToShop
{
    public interface IAddItemToShopUseCase
    {
        Task<Models.Item> Execute(string name, string description,
            decimal price, bool isHave, int countItem, Guid shopId,
            CancellationToken cancellationToken);
    }
}

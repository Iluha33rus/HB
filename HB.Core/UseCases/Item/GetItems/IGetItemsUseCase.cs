using System.Linq;

namespace HB.Core.UseCases.Item.GetItems
{
    public interface IGetItemsUseCase
    {
        Task<IEnumerable<Models.Item>> Execute(string shopName, CancellationToken cancellationToken);
    }
}

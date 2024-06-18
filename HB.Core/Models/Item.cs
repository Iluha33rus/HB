namespace HB.Core.Models
{
    public class Item
    {
        public required Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public bool IsHave { get; set; } = false; 
        public int Count { get; set; } = 0; //TODO: сделать зависимость от IsHave, а то получится, что товара нет, а в наличии количество будет показывать
        public required DateTimeOffset ItemAdded { get; set; }
        public required Guid ShopId { get; set; }
        public string ShopName { get; set; } = string.Empty;

    }
}

namespace HB.Core.Models
{
    public class Item
    {
        public required Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public bool IsHave { get; set; } = false;
        public int CountItem { get; set; } = 0;
        public required DateTimeOffset ItemAdded { get; set; }
        public required Guid ShopId { get; set; }
    }
}

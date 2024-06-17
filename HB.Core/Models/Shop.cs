namespace HB.Core.Models
{
    public class Shop
    {
        public required Guid ShopId { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required Guid UserId { get; set; }
    }
}

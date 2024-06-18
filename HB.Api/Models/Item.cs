namespace HB.Api.Models
{
    public class Item
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsHave { get; set; }
        public int CountItem { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; } = string.Empty; 
    }
}

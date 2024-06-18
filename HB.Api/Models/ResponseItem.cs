namespace HB.Api.Models
{
    public class ResponseItem
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsHave { get; set; }
        public int Count { get; set; }
        public string? ShopName { get; set; }
    }
}

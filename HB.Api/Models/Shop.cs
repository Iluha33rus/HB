namespace HB.Api.Models
{
    public class Shop
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset RegisteredAt { get; set; }
        public Guid UserId { get; set; }
    }
}
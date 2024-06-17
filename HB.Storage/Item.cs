using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HB.Storage
{
    public class Item
    {
        [Key]
        public required Guid ItemId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public bool IsHave { get; set; } = false;
        public int CountItem { get; set; } = 0;
        public required DateTimeOffset ItemAdded { get; set; }
        public required Guid ShopId { get; set; }
        [ForeignKey(nameof(ShopId))]
        public Shop? Shop { get; set; }
    }
}

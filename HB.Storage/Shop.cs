
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HB.Storage
{
    public class Shop
    {
        [Key]
        public required Guid ShopId { get; set; }
        public required DateTimeOffset RegisteredAt { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? Seller { get; set; } 
        [InverseProperty(nameof(Item.Shop))]
        public Collection<Item>? Items { get; set; }
    }
}

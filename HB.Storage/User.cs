using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HB.Storage
{
    public class User
    {
        [Key]
        public required Guid UserId { get; set; }
        public required DateTimeOffset RegisteredAt { get; set; }
        public required string Name { get; set; } 
        public required string Surname { get; set; } 
        public required string Email { get; set; } 
        [InverseProperty(nameof(Shop.Seller))]
        public Collection<Shop>? Shops { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace HB.Storage
{
    public class HwContext(DbContextOptions<HwContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}

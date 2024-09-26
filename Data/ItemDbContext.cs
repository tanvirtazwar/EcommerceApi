using EcommerceApi.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Item> Items { get; set; }
    }
}

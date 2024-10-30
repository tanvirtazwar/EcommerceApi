using EcommerceApi.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemDbContext(DbContextOptions<ItemDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }
    }
}

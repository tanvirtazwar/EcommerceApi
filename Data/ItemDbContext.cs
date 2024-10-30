using EcommerceApi.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ItemDbContext(DbContextOptions<ItemDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Item> Items { get; set; }
    }
}

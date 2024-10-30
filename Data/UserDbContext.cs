using EcommerceApi.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> dbContextOptions)
        : IdentityDbContext<AppUser>(dbContextOptions)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            const string sellerRoleId = "6e21de20-26ae-4792-8dc1-a239e65d3a9a";

            var roles = new List<IdentityRole>
            {
                new()
                {
                    Id=sellerRoleId,
                    ConcurrencyStamp=sellerRoleId,
                    Name = "Seller",
                    NormalizedName = "Seller".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

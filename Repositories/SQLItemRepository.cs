using EcommerceApi.Data;
using EcommerceApi.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{
    public class SqlItemRepository(ItemDbContext itemDb) : IItemRepository
    {
        public async Task<List<ItemSummary>> GetAllAsync()
        {
            return await itemDb.Items.AsNoTracking().Select(x => new ItemSummary()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Price = x.Price
            }).ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await itemDb.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> AddAsync(Item newItem)
        {
            newItem.Id = Guid.NewGuid();
            await itemDb.Items.AddAsync(newItem);
            await itemDb.SaveChangesAsync();
            return newItem;
        }

        public async Task<Item?> UpdateAsync(Guid id, Item updatedItem)
        {
            var item = await itemDb.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return null;
            }
            item.Name = updatedItem.Name;
            item.BrandName = updatedItem.BrandName;
            item.Color = updatedItem.Color;
            item.Ram = updatedItem.Ram;
            item.Rom = updatedItem.Rom;
            item.CameraMp = updatedItem.CameraMp;
            item.Image = updatedItem.Image;
            item.Price = updatedItem.Price;

            await itemDb.SaveChangesAsync();
            return updatedItem;
        }

        public async Task<Item?> RemoveAsync(Guid id)
        {
            var removedItem = await itemDb.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (removedItem == null)
            {
                return null;
            }

            itemDb.Items.Remove(removedItem);
            await itemDb.SaveChangesAsync();
            return removedItem;
        }
    }
}

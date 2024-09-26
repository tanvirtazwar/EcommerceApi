using EcommerceApi.Data;
using EcommerceApi.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{
    public class SQLItemRepository : IItemRepository
    {
        private readonly ItemDbContext itemDb;

        public SQLItemRepository(ItemDbContext itemDb)
        {
            this.itemDb = itemDb;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await itemDb.Items.ToListAsync();
        }

        public async Task<Item?> GetByIDAsync(Guid id)
        {
            return await itemDb.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> CreateAsync(Item newItem)
        {
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
            item.CameraMP = updatedItem.CameraMP;
            item.Image = updatedItem.Image;
            item.Price = updatedItem.Price;

            await itemDb.SaveChangesAsync();
            return updatedItem;
        }

        public async Task<Item?> DeleteAsync(Guid id)
        {
            var item = await itemDb.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return null;
            }

            itemDb.Items.Remove(item);
            await itemDb.SaveChangesAsync();
            return item;
        }
    }
}

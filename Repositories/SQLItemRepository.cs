using EcommerceApi.Data;
using EcommerceApi.Models.Domains;
using EcommerceApi.Querying;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Repositories
{
    public class SqlItemRepository(ItemDbContext itemDb) : IItemRepository
    {
        public async Task<List<ItemSummary>> GetAllAsync
            (QueryObject queryObject)
        {
            var queryable = itemDb.Items.AsQueryable();

            queryable = string.IsNullOrEmpty(queryObject.Name) ? queryable 
                : queryable.Where(item => item.Name.Contains(queryObject.Name));
            queryable = string.IsNullOrEmpty(queryObject.BrandName) ? queryable 
                : queryable.Where(item => item.BrandName.Contains(queryObject.BrandName));
            queryable = string.IsNullOrEmpty(queryObject.Color) ? queryable 
                : queryable.Where(item => item.Color.Contains(queryObject.Color));
            queryable = string.IsNullOrEmpty(queryObject.Ram) ? queryable 
                : queryable.Where(item => item.Ram.Contains(queryObject.Ram));
            queryable = string.IsNullOrEmpty(queryObject.Rom) ? queryable 
                : queryable.Where(item => item.Rom.Contains(queryObject.Rom));
            queryable = queryObject.CameraMp == null ? queryable
                : queryable.Where(item => item.CameraMp.Equals(queryObject.CameraMp));
            queryable = queryObject.Price == null ? queryable
                : queryable.Where(item => item.Price.Equals(queryObject.Price));

            if (!string.IsNullOrEmpty(queryObject.SortBy))
            {
                if (queryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.Name) 
                        : queryable.OrderByDescending(item => item.Name);
                }
                else if (queryObject.SortBy.Equals("BrandName", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.BrandName) 
                        : queryable.OrderByDescending(item => item.BrandName);
                }
                else if (queryObject.SortBy.Equals("Color", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.Color) 
                        : queryable.OrderByDescending(item => item.Color);
                }
                else if (queryObject.SortBy.Equals("Ram", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.Ram) 
                        : queryable.OrderByDescending(item => item.Ram);
                }
                else if (queryObject.SortBy.Equals("Rom", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.Rom) 
                        : queryable.OrderByDescending(item => item.Rom);
                }
                else if (queryObject.SortBy.Equals("CameraMp", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.CameraMp) 
                        : queryable.OrderByDescending(item => item.CameraMp);
                }
                else if (queryObject.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    queryable = queryObject.IsDescending? queryable.OrderBy(item => item.Price) 
                        : queryable.OrderByDescending(item => item.Price);
                }
            }
            
            var skipNumber = (queryObject.PageNumber - 1)* queryObject.PageSize;
            
            var items = await queryable.AsNoTracking()
                .Select(x => new ItemSummary
                {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Price = x.Price
            }).Skip(skipNumber)
                .Take(queryObject.PageSize)
                .ToListAsync();
            
            return items;
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

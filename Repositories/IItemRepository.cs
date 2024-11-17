using EcommerceApi.Models.Domains;
using EcommerceApi.Querying;

namespace EcommerceApi.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemSummary>> GetAllAsync
            (QueryObject queryObject);

        Task<Item?> GetByIdAsync(Guid id);

        Task<Item> AddAsync(Item newItem);

        Task<Item?> UpdateAsync(Guid id, Item updatedItem);

        Task<Item?> RemoveAsync(Guid id);
    }
}

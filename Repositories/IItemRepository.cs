using EcommerceApi.Models.Domains;

namespace EcommerceApi.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemSummary>> GetAllAsync();

        Task<Item?> GetByIDAsync(Guid id);

        Task<Item> AddAsync(Item newItem);

        Task<Item?> UpdateAsync(Guid id, Item updatedItem);

        Task<Item?> RemoveAsync(Guid id);
    }
}

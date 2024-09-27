using EcommerceApi.Models.Domains;

namespace EcommerceApi.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();

        Task<Item?> GetByIDAsync(Guid id);

        Task<Item> CreateAsync(Item newItem);

        Task<Item?> UpdateAsync(Guid id, Item updatedItem);

        Task<Item?> DeleteAsync(Guid id);
    }
}

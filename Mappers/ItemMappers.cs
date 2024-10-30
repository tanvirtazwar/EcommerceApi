using EcommerceApi.Models.Domains;
using EcommerceApi.Models.Dtos;

namespace EcommerceApi.Mappers
{
    public static class ItemMappers
    {
        public static Item ToItem (this ItemDto dto)
        {
            return new Item
            {
                Name = dto.Name,
                BrandName = dto.BrandName,
                Color = dto.Color,
                Ram = dto.Ram,
                Rom = dto.Rom,
                CameraMp = dto.CameraMp,
                Image = dto.Image,
                Price = dto.Price,
            };
        }
    }
}

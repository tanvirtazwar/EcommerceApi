using EcommerceApi.Mappers;
using EcommerceApi.Models.Domains;
using EcommerceApi.Models.Dtos;
using EcommerceApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemSummary()
        {
            var itemsSummary = await itemRepository.GetAllAsync();

            return Ok(itemsSummary);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetItemByID([FromRoute] Guid id)
        {
            var itemDomain = await itemRepository.GetByIDAsync(id);
            if (itemDomain == null)
            {
                return NotFound();
            }

            return Ok(itemDomain);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            var item = await itemRepository.AddAsync(itemDto.ToItem());
            return CreatedAtAction(nameof(GetItemByID), new { item.Id },item);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] ItemDto itemDto)
        {
            var updatedItem = await itemRepository.UpdateAsync(id, itemDto.ToItem());
            if (updatedItem == null)
            {
                return NotFound();
            }

            return Ok(updatedItem);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> RemoveItem([FromRoute] Guid id)
        {
            var removedItem = await itemRepository.RemoveAsync(id);
            if (removedItem == null)
            {
                return NotFound();
            }

            return Ok(removedItem);
        }
    }
}

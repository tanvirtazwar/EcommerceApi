using EcommerceApi.Mappers;
using EcommerceApi.Models.Dtos;
using EcommerceApi.Querying;
using EcommerceApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController(IItemRepository itemRepository) : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 10)]
        public async Task<IActionResult> GetAllItemSummary
            ([FromQuery] QueryObject queryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemsSummary = 
                await itemRepository.GetAllAsync(queryObject);

            return Ok(itemsSummary);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetItemById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemDomain = await itemRepository.GetByIdAsync(id);
            if (itemDomain == null)
            {
                return NotFound();
            }

            return Ok(itemDomain);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await itemRepository.AddAsync(itemDto.ToItem());
            return CreatedAtAction(nameof(GetItemById), new { item.Id },item);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var removedItem = await itemRepository.RemoveAsync(id);
            if (removedItem == null)
            {
                return NotFound();
            }

            return Ok(removedItem);
        }
    }
}

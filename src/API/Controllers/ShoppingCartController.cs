using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Entities;
using Webshop.API.Models;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Controllers
{
    [ApiController]
    [Route("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _ShoppingCartRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartRepository ShoppingCartRepository, IMapper mapper)
        {
            _ShoppingCartRepository = ShoppingCartRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartDto>>> GetShoppingCarts()
        {
            var shoppingCarts = await _ShoppingCartRepository.GetShoppingCartsAsync();
            return Ok(_mapper.Map<IEnumerable<ShoppingCartDto>>(shoppingCarts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetShoppingCart(Guid id)
        {
            var ShoppingCart = await _ShoppingCartRepository.GetShoppingCartAsync(id);

            if (ShoppingCart == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ShoppingCartDto>(ShoppingCart));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDto>> AddShoppingCart(ShoppingCartDto ShoppingCartDto)
        {
            var ShoppingCart = await _ShoppingCartRepository.AddShoppingCartAsync(_mapper.Map<ShoppingCart>(ShoppingCartDto));
            await _ShoppingCartRepository.SaveChangesAsync();
            return Ok(_mapper.Map<ShoppingCartDto>(ShoppingCart));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateShoppingCart(ShoppingCartDto ShoppingCartDto)
        {
            var ShoppingCart = await _ShoppingCartRepository.GetShoppingCartAsync(ShoppingCartDto.UserId);
            if (ShoppingCart == null)
            {
                return NotFound();
            }
            _ShoppingCartRepository.UpdateShoppingCart(_mapper.Map<ShoppingCart>(ShoppingCartDto));
            await _ShoppingCartRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a specific file
        /// <summary>
        /// <param name="id">Guid of a ShoppingCart</param>
        /// <returns>/</returns>
        /// <remarks>
        /// Attention: The ShoppingCart will be deleted
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShoppingCart(Guid id)
        {
            var shoppingCart = await _ShoppingCartRepository.GetShoppingCartAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            _ShoppingCartRepository.DeleteShoppingCart(shoppingCart);
            return NoContent();
        }
    }
}

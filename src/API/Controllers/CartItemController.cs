using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webshop.API.Entities;
using Webshop.API.Models;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Controllers
{
    [ApiController]
    [Route("api/CartItem")]
    public class CartItenController : Controller
    {
        private readonly ICartItemRepository _CartItemRepository;
        private readonly IMapper _mapper;

        public CartItenController(ICartItemRepository CartItemRepository, IMapper mapper)
        {
            _CartItemRepository = CartItemRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCartItems()
        {
            var CartItems = await _CartItemRepository.GetCartItemsAsync();
            return Ok(_mapper.Map<IEnumerable<CartItemDto>>(CartItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCartItem(Guid id)
        {
            var CartItem = await _CartItemRepository.GetCartItemAsync(id);

            if (CartItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CartItemDto>(CartItem));
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> AddCartItem(CartItemDto CartItemDto)
        {
            var CartItem = await _CartItemRepository.AddCartItemAsync(_mapper.Map<CartItem>(CartItemDto));
            await _CartItemRepository.SaveChangesAsync();
            return Ok(_mapper.Map<CartItemDto>(CartItem));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCartItem(CartItemDto CartItemDto)
        {
            var cartItem = await _CartItemRepository.GetCartItemAsync(CartItemDto.Id);
            if (cartItem == null)
            {
                return NotFound();
            }
            _CartItemRepository.UpdateCartItem(_mapper.Map<CartItem>(CartItemDto));
            await _CartItemRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a specific file
        /// <summary>
        /// <param name="id">Guid of a CartItem</param>
        /// <returns>/</returns>
        /// <remarks>
        /// Attention: The CartItem will be deleted
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCartItem(Guid id)
        {
            var cartItem = await _CartItemRepository.GetCartItemAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _CartItemRepository.DeleteCartItem(cartItem);
            return NoContent();
        }
    }
}

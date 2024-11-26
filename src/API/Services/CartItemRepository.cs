using Microsoft.EntityFrameworkCore;
using Webshop.API.DbContexts;
using Webshop.API.Entities;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Services
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly WebshopDbContext _context;

        public CartItemRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem> AddCartItemAsync(CartItem CartItem)
        {
            await _context.CartItems.AddAsync(CartItem);
            return CartItem;
        }

        public void DeleteCartItem(CartItem CartItem)
        {
            _context.CartItems.Remove(CartItem);
        }
        public async Task<CartItem?> GetCartItemAsync(Guid id)
        {
            return await _context.CartItems.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await _context.CartItems.OrderBy(p => p.Id).AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateCartItem(CartItem CartItem)
        {
            _context.CartItems.Update(CartItem);
        }
    }
}

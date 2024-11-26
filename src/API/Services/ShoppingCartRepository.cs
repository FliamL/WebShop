using Microsoft.EntityFrameworkCore;
using Webshop.API.DbContexts;
using Webshop.API.Entities;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly WebshopDbContext _context;

        public ShoppingCartRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart ShoppingCart)
        {
            await _context.ShoppingCarts.AddAsync(ShoppingCart);
            return ShoppingCart;
        }

        public void DeleteShoppingCart(ShoppingCart ShoppingCart)
        {
            _context.ShoppingCarts.Remove(ShoppingCart);
        }
        public async Task<ShoppingCart?> GetShoppingCartAsync(Guid id)
        {
            return await _context.ShoppingCarts.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetShoppingCartsAsync()
        {
            return await _context.ShoppingCarts.OrderBy(p => p.Id).AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateShoppingCart(ShoppingCart ShoppingCart)
        {
            _context.ShoppingCarts.Update(ShoppingCart);
        }
    }
}

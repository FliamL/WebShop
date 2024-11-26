using Webshop.API.Entities;

namespace Webshop.API.Services.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<IEnumerable<ShoppingCart>> GetShoppingCartsAsync();

        Task<ShoppingCart?> GetShoppingCartAsync(Guid id);
        Task<ShoppingCart> AddShoppingCartAsync(ShoppingCart ShoppingCart);

        void UpdateShoppingCart(ShoppingCart ShoppingCart);

        void DeleteShoppingCart(ShoppingCart ShoppingCart);

        Task<bool> SaveChangesAsync();
    }
}

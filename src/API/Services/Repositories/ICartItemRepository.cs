using Webshop.API.Entities;

namespace Webshop.API.Services.Repositories
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();

        Task<CartItem?> GetCartItemAsync(Guid id);
        Task<CartItem> AddCartItemAsync(CartItem CartItem);

        void UpdateCartItem(CartItem CartItem);

        void DeleteCartItem(CartItem CartItem);

        Task<bool> SaveChangesAsync();
    }
}

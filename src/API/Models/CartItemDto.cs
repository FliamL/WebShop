using Webshop.API.Entities;

namespace Webshop.API.Models
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid GameId { get; set; }
        public int Quantity { get; set; }

    }
}

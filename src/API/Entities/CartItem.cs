using Webshop.API.Models;

namespace Webshop.API.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; } // Primary Key
        public Guid ShoppingCartId { get; set; } // Foreign Key to ShoppingCart
        public Guid GameId { get; set; } // Foreign Key to Game
        public int Quantity { get; set; } // Quantity of the game in the cart

        // Navigation properties
        public virtual ShoppingCart? ShoppingCart { get; set; } // The shopping cart that contains this item
        public virtual Game? Game { get; set; } // The game associated with this cart item
    }
}

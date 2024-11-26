namespace Webshop.API.Entities
{
    public class Game
    {
        public Guid Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty; // Name of the game
        public string Description { get; set; } = string.Empty; // Description of the game
        public double Price { get; set; } // Price of the game
        public string ImageUrl { get; set; } = string.Empty; // Image URL for the game
        public bool InStock { get; set; } // Availability status

        // Navigation property
        public virtual ICollection<CartItem>? CartItems { get; set; } // The cart items that contain this game
    }
}

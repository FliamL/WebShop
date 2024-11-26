using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Webshop.API.Models;

namespace Webshop.API.Entities
{
    public class ShoppingCart
    {
        [Key] // Primary Key
        public Guid Id { get; set; }

        [Required] // UserId is required
        public string UserId { get; set; } = string.Empty; // FK to User

        [ForeignKey(nameof(UserId))] // Foreign key relationship
        public virtual User? User { get; set; } // Navigation property to User

        public virtual ICollection<CartItem>? CartItems { get; set; } // Navigation property to CartItems
    }
}

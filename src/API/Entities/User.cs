using Microsoft.AspNetCore.Identity;

namespace Webshop.API.Entities
{
    public class User : IdentityUser
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Optional navigation property for the ShoppingCart
        public virtual ShoppingCart? ShoppingCart { get; set; }
    }
}

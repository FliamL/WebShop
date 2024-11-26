using Webshop.API.Entities;

namespace Webshop.API.Models
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}

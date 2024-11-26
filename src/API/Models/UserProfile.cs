namespace Webshop.API.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;// FK to AspNetUsers
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

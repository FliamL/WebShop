﻿namespace WebShop.Api.Models
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}

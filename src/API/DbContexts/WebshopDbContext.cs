using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webshop.API.Entities;

namespace Webshop.API.DbContexts
{
    public class WebshopDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public WebshopDbContext(DbContextOptions<WebshopDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
               new Game
               {
                   Id = Guid.Parse("61eaf3e1-1a93-4492-9d00-0b8305eff479"),
                   Name = "The Witcher 3",
                   Description = "An action RPG game set in a dark fantasy world.",
                   Price = 39.99,
                   ImageUrl = "https://example.com/images/witcher3.jpg",
                   InStock = true
               },
               new Game
               {
                   Id = Guid.Parse("d2e156f3-3d0c-4e37-b970-3d66b00dbc43"),
                   Name = "Cyberpunk 2077",
                   Description = "A futuristic open-world RPG.",
                   Price = 59.99,
                   ImageUrl = "https://example.com/images/cyberpunk2077.jpg",
                   InStock = true
               }
           );

            var user = new User
            {
                Id = "3dd39969-156d-46ae-9cde-1106e7623255",
                Address = "Citadellaan 54",
                City = "Diest",
                Email = "liam@brobots.be",
                Country = "Belgium",
                PhoneNumber = "1234567890"
            };

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = user.Id,
                Address = user.Address,
                City = user.City,
                Email = user.Email,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber
            });

            // Seed data for ShoppingCart
            var cartId = Guid.NewGuid(); // Create a new cart ID

            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart
                {
                    Id = Guid.Parse("8ee19677-b610-492b-aa99-81a645fc2fcc"), // This can be auto-generated or specific
                    UserId = user.Id,
                }
            );

            // Seed data for CartItems
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    ShoppingCartId = Guid.Parse("8ee19677-b610-492b-aa99-81a645fc2fcc"), // Link to the ShoppingCart
                    GameId = Guid.Parse("61eaf3e1-1a93-4492-9d00-0b8305eff479"),
                    Quantity = 2
                },
                new CartItem
                {
                    Id = Guid.NewGuid(),
                    ShoppingCartId = Guid.Parse("8ee19677-b610-492b-aa99-81a645fc2fcc"),
                    GameId = Guid.Parse("d2e156f3-3d0c-4e37-b970-3d66b00dbc43"),
                    Quantity = 1
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1", // Unique identifier for the role
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            modelBuilder.HasDefaultSchema("identity");
            base.OnModelCreating(modelBuilder);
        }
    }
}

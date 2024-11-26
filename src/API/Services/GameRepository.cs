using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;
using Webshop.API.DbContexts;
using Webshop.API.Entities;
using Webshop.API.Services.Repositories;

namespace Webshop.API.Services
{
    public class GameRepository : IGameRepository
    {
        private readonly WebshopDbContext _context;

        public GameRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGameAsync(Game Game)
        {
            await _context.Games.AddAsync(Game);
            return Game;
        }

        public void DeleteGame(Game Game)
        {
            _context.Games.Remove(Game);
        }
        public async Task<Game?> GetGameAsync(Guid id)
        {
            return await _context.Games.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.OrderBy(p => p.Name).AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateGame(Game Game)
        {
            _context.Games.Update(Game);
        }
    }
}

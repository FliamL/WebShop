using System.IO.Pipelines;
using Webshop.API.Entities;

namespace Webshop.API.Services.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();

        Task<Game?> GetGameAsync(Guid id);
        Task<Game> AddGameAsync(Game Game);

        void UpdateGame(Game Game);

        void DeleteGame(Game Game);

        Task<bool> SaveChangesAsync();
    }
}

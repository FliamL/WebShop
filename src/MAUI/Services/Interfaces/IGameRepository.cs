using C_MobileProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Services.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGames(string token);
    }
}

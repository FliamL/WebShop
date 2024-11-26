using C_MobileProject.Models;
using C_MobileProject.Services.Repositories;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_MobileProject.Services
{
    public class GameRepository : IGameRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://14hwgcz0-7226.euw.devtunnels.ms/api/games";

        public GameRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Game>> GetAllGames(string token)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new List<Game>();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string reponse = await _httpClient.GetStringAsync(baseUrl);
            return JsonSerializer.Deserialize<List<Game>>(reponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}

using C_MobileProject.Models;
using C_MobileProject.Models.Reponses;
using C_MobileProject.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_MobileProject.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://14hwgcz0-7226.euw.devtunnels.ms/api/ShoppingCart";

        public ShoppingCartRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task CreateShoppingCart(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;
            var message = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}register");
            message.Content = JsonContent.Create(user);
            var response = await _httpClient.SendAsync(message);

            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ShoppingCart>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

        }
    }
}

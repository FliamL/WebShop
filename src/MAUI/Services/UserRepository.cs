using C_MobileProject.Models;
using C_MobileProject.Models.Reponses;
using C_MobileProject.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_MobileProject.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://14hwgcz0-7226.euw.devtunnels.ms/api/auth/";

        public UserRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<LoginResponse> DoLogin(User userLogin)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new LoginResponse();
            var message = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}login");
            message.Content = JsonContent.Create(userLogin);
            var response = await _httpClient.SendAsync(message);

            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<LoginResponse> DoRegister(User userRegister)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return new LoginResponse();
            var message = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}register");
            message.Content = JsonContent.Create(userRegister);
            var response = await _httpClient.SendAsync(message);

            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}

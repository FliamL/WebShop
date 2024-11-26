using C_MobileProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Services
{
    public class TokenService : ITokenService
    {
        public async Task SaveTokenAsync(string token)
        {
			try
			{
				await SecureStorage.SetAsync("bearer_token", token);
			}
			catch (Exception ex)
			{
                // Handle errors (e.g., SecureStorage not available on the device)
                Console.WriteLine($"SecureStorage error: {ex.Message}");
            }
        }

        public async Task<string> GetTokenAsync()
        {
            var token = await SecureStorage.GetAsync("bearer_token");
            if (token != null) 
                return token;
            return string.Empty;
        }
    }
}

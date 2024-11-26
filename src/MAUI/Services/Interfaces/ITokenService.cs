using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Services.Interfaces
{
    public interface ITokenService
    {
        Task SaveTokenAsync(string token);
        Task<string> GetTokenAsync();
    }
}

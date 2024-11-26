using C_MobileProject.Models;
using C_MobileProject.Models.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Services.Repositories
{
    public interface IUserRepository
    {
        Task<LoginResponse> DoLogin(User userLogin);
        Task<LoginResponse> DoRegister(User userRegister);
    }
}

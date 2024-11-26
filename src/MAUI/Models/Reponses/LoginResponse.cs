using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_MobileProject.Models.Reponses
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;  // The JWT access token
    }
}

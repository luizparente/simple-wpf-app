using Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> AuthenticateAsync(string username, string password, string method)
        {
            if (username == "luiz" && password == "parente" && method == "2FA")
            {
                return true;
            }

            return false;
        }
    }
}

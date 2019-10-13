using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Security.Auth.Requests
{
    public class LoginRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }

        public LoginRequest(string userName, string password, string ipAddress)
        {
            UserName = userName;
            Password = password;
            IpAddress = ipAddress;
        }
    }
}

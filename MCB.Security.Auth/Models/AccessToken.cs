using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Security.Auth.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }

        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}

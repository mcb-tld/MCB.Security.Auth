using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Security.Auth.Requests
{
    public class RefreshTokenRequest : IRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public RefreshTokenRequest(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}

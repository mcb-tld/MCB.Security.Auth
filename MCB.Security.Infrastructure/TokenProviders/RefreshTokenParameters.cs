using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class RefreshTokenParameters
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string SigningKey { get; set; }

        public RefreshTokenParameters(string accessToken, string refreshToken, string signingKey)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
        }
    }
}

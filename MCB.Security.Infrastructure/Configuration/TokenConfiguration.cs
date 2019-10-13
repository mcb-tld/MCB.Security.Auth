using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Configuration
{
    public class TokenConfiguration
    {
        public static readonly int AccessTokenExpiration = 300; //5 mins
        public static readonly int RefreshTokenExpiration = 108000; //30 days
        public static readonly TokenProviderEnum TokenProvider = TokenProviderEnum.Jwt;
        public static readonly string SecretKey = "SECRET_KEY_GOES_HERE";
    }
}

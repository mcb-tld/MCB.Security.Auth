using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class AccessTokenParameters
    {
        public int UserGuid { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public int ExpiresIn { get; set; }
        public string SigningKey { get; set; }

        public AccessTokenParameters(int userGuid, string userName, string[] roles, int expiresIn, string signingKey)
        {
            UserGuid = userGuid;
            UserName = userName;
            Roles = roles;
            ExpiresIn = expiresIn;
            SigningKey = signingKey;
        }
    }
}

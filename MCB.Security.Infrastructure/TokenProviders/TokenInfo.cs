using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}

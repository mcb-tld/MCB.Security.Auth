using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Configuration
{
    public enum TokenProviderEnum
    {
        Builtin = 1, //Used for refresh tokens
        Jwt = 2
    }
}

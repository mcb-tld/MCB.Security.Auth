using MCB.Security.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public interface ITokenProviderFactory
    {
        ITokenFactory GetTokenFactory(TokenProviderEnum tokenProviderEnum);
    }
}
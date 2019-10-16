using System;
using System.Collections.Generic;
using System.Text;
using MCB.Security.Infrastructure.Configuration;
using MCB.Security.Infrastructure.TokenProviders.Jwt;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class TokenProviderFactory : ITokenProviderFactory
    {
        private Dictionary<TokenProviderEnum, ITokenFactory> _currentTokenFactories;

        public TokenProviderFactory()
        {
            _currentTokenFactories = new Dictionary<TokenProviderEnum, ITokenFactory>();
        }

        public ITokenFactory GetTokenFactory(TokenProviderEnum tokenProviderEnum)
        {
            if (_currentTokenFactories.ContainsKey(tokenProviderEnum))
                return _currentTokenFactories[tokenProviderEnum];

            switch (tokenProviderEnum)
            {
                case TokenProviderEnum.Jwt:
                    return _currentTokenFactories[tokenProviderEnum] = new JwtTokenFactory();
                default:
                    throw new NotSupportedException($"token provider not found: {tokenProviderEnum.ToString()}");
            }
        }
    }
}

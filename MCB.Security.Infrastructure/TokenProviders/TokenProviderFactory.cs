using System;
using System.Collections.Generic;
using System.Linq;
using MCB.Security.Infrastructure.Configuration;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class TokenProviderFactory : ITokenProviderFactory
    {
        private Dictionary<TokenProviderEnum, ITokenFactory> _currentTokenFactories;
        private readonly IEnumerable<ITokenFactory> _tokenFactories;

        public TokenProviderFactory(IEnumerable<ITokenFactory> tokenFactories)
        {
            _tokenFactories = tokenFactories;
            _currentTokenFactories = new Dictionary<TokenProviderEnum, ITokenFactory>();
        }

        public ITokenFactory GetTokenFactory(TokenProviderEnum tokenProviderEnum)
        {
            if (_currentTokenFactories.ContainsKey(tokenProviderEnum))
                return _currentTokenFactories[tokenProviderEnum];

            IEnumerable<ITokenFactory> matchedFactories = _tokenFactories.Where(f => f.TokenProvider.Equals(tokenProviderEnum));
            if (matchedFactories.Count() == 0)
            {
                throw new NotSupportedException($"Token provider not found: {tokenProviderEnum.ToString()}");
            }
            else if (matchedFactories.Count() > 1)
            {
                throw new NotSupportedException($"More than 1 providers found for: {tokenProviderEnum.ToString()}");
            }
            else
                return matchedFactories.Single();
        }
    }
}

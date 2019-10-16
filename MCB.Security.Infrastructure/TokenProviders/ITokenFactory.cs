using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public interface ITokenFactory
    {
        Task<TokenInfo> GenerateAccessToken(AccessTokenParameters parameters);
        Task<TokenInfo> GenerateRefreshToken(int tokenSize, int expiresIn);
    }
}
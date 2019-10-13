using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public interface ITokenFactory
    {
        Task<TokenInfo> GenerateToken(AccessTokenParameters parameters);
        Task<TokenInfo> RefreshToken(RefreshTokenParameters parameters);
    }
}
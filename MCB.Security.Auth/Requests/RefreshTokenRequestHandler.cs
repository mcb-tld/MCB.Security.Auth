using MCB.Security.Infrastructure.Configuration;
using MCB.Security.Infrastructure.Data.Entities;
using MCB.Security.Infrastructure.Data.Repositories;
using MCB.Security.Infrastructure.TokenProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Security.Auth.Requests
{
    public interface IRefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest> { }

    public class RefreshTokenRequestHandler : IRefreshTokenRequestHandler
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly IUserRepository _userRepository;

        public RefreshTokenRequestHandler(ITokenProviderFactory tokenProviderFactory, IUserRepository userRepository)
        {
            _tokenFactory = tokenProviderFactory.GetTokenFactory(TokenConfiguration.TokenProvider);
            _userRepository = userRepository;
        }

        public async Task<Response> HandleAsync(RefreshTokenRequest request)
        {
            UserIdentity userIdentity = _tokenFactory.GetUserIdentity(request.AccessToken, TokenConfiguration.SecretKey);
            
            if (userIdentity != null)
            {
                var userEntity = await _userRepository.GetUserAsync(userIdentity.Id);

                if (userEntity != null && userEntity.IsValidRefreshToken(request.RefreshToken))
                {
                    userEntity.RemoveRefreshToken(request.RefreshToken);
                    TokenInfo refreshToken = await _tokenFactory.GenerateRefreshToken(TokenConfiguration.RefreshTokenSize, TokenConfiguration.RefreshTokenExpiration);
                    userEntity.AddRefreshToken(refreshToken.Token, refreshToken.ExpiresIn);
                    await _userRepository.UpdateUser(userEntity);

                    AccessTokenParameters accessTokenParameters = new AccessTokenParameters
                    (
                        userEntity.SiteUserGuid,
                        userEntity.SiteUserName,
                        TokenConfiguration.AccessTokenExpiration,
                        TokenConfiguration.SecretKey
                    );
                    TokenInfo accessToken = await _tokenFactory.GenerateAccessToken(accessTokenParameters);
                    return new Response(accessToken.Token, refreshToken.Token);
                }
            }

            return null;
        }
    }
}

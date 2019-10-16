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
    public interface ILoginRequestHandler : IRequestHandler<LoginRequest> { }

    public class LoginRequestHandler : ILoginRequestHandler
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(ITokenProviderFactory tokenProviderFactory, IUserRepository userRepository)
        {
            _tokenFactory = tokenProviderFactory.GetTokenFactory(TokenConfiguration.TokenProvider);
            _userRepository = userRepository;
        }

        public async Task<Response> HandleAsync(LoginRequest request)
        {
            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
                SiteUserEntity userEntity = await _userRepository.GetUserAsync(request.UserName, request.Password);
                if (userEntity != null)
                {
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

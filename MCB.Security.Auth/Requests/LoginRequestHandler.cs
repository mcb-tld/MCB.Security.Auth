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
        private readonly ITokenFactory _accessTokenFactory;
        private readonly ITokenFactory _refreshTokenFactory;
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(ITokenProviderFactory tokenProviderFactory, IUserRepository userRepository)
        {
            _accessTokenFactory = tokenProviderFactory.GetTokenFactory(TokenConfiguration.TokenProvider);
            _refreshTokenFactory = tokenProviderFactory.GetTokenFactory(TokenProviderEnum.Builtin);
            _userRepository = userRepository;
        }

        public async Task<Response> HandleAsync(LoginRequest request)
        {
            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
                UserEntity userEntity = await _userRepository.GetUserAsync(request.UserName, request.Password);
                if (userEntity != null)
                { 
                   
                }
            }

            return null;
        }
    }
}

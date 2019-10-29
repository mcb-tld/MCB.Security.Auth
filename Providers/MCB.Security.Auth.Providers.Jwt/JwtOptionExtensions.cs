using MCB.Security.Infrastructure.TokenProviders;
using MCB.Security.Infrastructure.TokenProviders.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Auth.Providers.Jwt
{
    public class JwtOptionExtensions : ISecurityOptionExtensions
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddSingleton<ITokenFactory, JwtTokenFactory>();
        }
    }
}

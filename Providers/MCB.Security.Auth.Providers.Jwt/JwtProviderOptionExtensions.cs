using MCB.Security.Auth.Providers.Jwt;
using MCB.Security.Infrastructure.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JwtProviderOptionExtensions
    {
        public static SecurityProviderOptions UseJwt(this SecurityProviderOptions options)
        {
            options.RegisterExtension(new JwtOptionExtensions());
            return options;
        }
    }
}

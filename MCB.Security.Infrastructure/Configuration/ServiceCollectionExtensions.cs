using MCB.Security.Infrastructure.Configuration;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurityProvider(this IServiceCollection services, Action<SecurityProviderOptions> setupAction)
        {
            if (setupAction == null)
                throw new ArgumentNullException();

            var options = new SecurityProviderOptions();
            setupAction(options);
            foreach (var serviceExtension in options.Extensions)
            {
                serviceExtension.AddServices(services);
            }
            services.AddSingleton(options);

            return services;
        }
    }
}

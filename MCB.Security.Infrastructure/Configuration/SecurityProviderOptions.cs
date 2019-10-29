using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Configuration
{
    public class SecurityProviderOptions
    {
        public SecurityProviderOptions()
        {
            Extensions = new List<ISecurityOptionExtensions>();
        }

        public IList<ISecurityOptionExtensions> Extensions { get; }

        public void RegisterExtension(ISecurityOptionExtensions extension)
        {
            if (extension == null)
                throw new ArgumentNullException();

            Extensions.Add(extension);
        }
    }
}

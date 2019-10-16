using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MCB.Security.Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args)
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                   .AddEnvironmentVariables()
                                                   .Build();

            var host = new WebHostBuilder().UseConfiguration(config)
#if DEBUG
                                           .UseKestrel()
#endif
                                           .UseIIS()
                                           .UseStartup<Startup>();

            host.Build().Run();
        }
    }
}

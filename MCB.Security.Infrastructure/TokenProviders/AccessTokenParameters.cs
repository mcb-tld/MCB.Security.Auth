using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class AccessTokenParameters
    {
        public int UserGuid { get; set; }
        public string UserName { get; set; }
    }
}

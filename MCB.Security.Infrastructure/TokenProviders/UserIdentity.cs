using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.TokenProviders
{
    public class UserIdentity
    {
        public int Id { get; set; }

        public UserIdentity(int id)
        {
            Id = id;
        }
    }
}

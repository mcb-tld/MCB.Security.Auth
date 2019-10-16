using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Entities
{
    public class SiteUserEntity : BaseEntity
    {
        public int SiteUserGuid { get; set; }
        public string SiteUserName { get; set; }
        public string SiteUserPassword { get; set; }
        public string SiteUserEmail { get; set; }
        public int SiteGuid { get; set; }
        public int SiteUserEmailVerifiedCount { get; set; }
        public int SiteUserEmailVerifiedFailCount { get; set; }
        public int ImportOriginGuid { get; set; }
        public bool SiteUserSalesPersonSystemAccess { get; set; }
        public bool MoveToOtherCustomer { get; set; }
        public int HashType { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        //public List<UserRole> Roles { get; set; }

        public bool IsValidRefreshToken(string refreshToken)
        {
            return RefreshTokens.Any(e => e.Token.Equals(refreshToken) && e.IsValid);
        }

        public void AddRefreshToken(string token, int expiration)
        {
            RefreshTokens.Add(new RefreshToken() { Token = token, Expiration = DateTime.Now.AddSeconds(expiration) });
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            RefreshToken token = RefreshTokens.FirstOrDefault(e => e.Token.Equals(refreshToken));
            if (token != null)
                RefreshTokens.Remove(token);
        }
    }
}

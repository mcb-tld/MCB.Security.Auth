using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Entities
{
    public class AdminUserEntity : BaseEntity
    {
        public int UserGuid { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public bool UserAdminAccess { get; set; }
        public bool ContentPreserveLanguage { get; set; }
        public bool HasBeenLoggedInMyAccumolo { get; set; }
        public bool IsDeactivated { get; set; }
        public bool HasAccessToSitesWithSensitiveData { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

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

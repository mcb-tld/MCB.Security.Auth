using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Guid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public List<UserRole> Roles { get; set; }

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

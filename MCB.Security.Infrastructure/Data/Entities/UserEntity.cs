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
        private List<RefreshToken> _refreshTokens = new List<RefreshToken>();

        public bool IsValidRefreshToken(string refreshToken)
        {
            return _refreshTokens.Any(e => e.Token.Equals(refreshToken) && e.IsValid);
        }

        public void AddRefreshToken(string token, int expiration)
        {
            _refreshTokens.Add(new RefreshToken() { Token = token, Expiration = DateTime.Now.AddSeconds(expiration) });
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            RefreshToken token = _refreshTokens.FirstOrDefault(e => e.Token.Equals(refreshToken));
            if (token != null)
                _refreshTokens.Remove(token);
        }
    }
}

using MCB.Security.Infrastructure.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Security.Infrastructure.TokenProviders.Jwt
{
    public class JwtTokenFactory : ITokenFactory
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtTokenFactory()
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<TokenInfo> GenerateAccessToken(AccessTokenParameters parameters)
        {
            var identity = GenerateClaimsIdentity(parameters.UserGuid, parameters.UserName);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddSeconds(parameters.ExpiresIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(parameters.SigningKey)), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
          
            return new TokenInfo(_jwtSecurityTokenHandler.WriteToken(token), parameters.ExpiresIn);
        }

        public async Task<TokenInfo> GenerateRefreshToken(int tokenSize, int expiresIn)
        { 
            var randomNumber = new byte[tokenSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                string refreshToken = Convert.ToBase64String(randomNumber);

                return new TokenInfo(refreshToken, expiresIn);
            }
        }

        public UserIdentity GetUserIdentity(string accessToken, string signingKey)
        {
            ClaimsPrincipal cp = GetPrincipalFromToken(accessToken, signingKey);
            if (cp != null && int.TryParse(cp.Claims.First(c => c.Type == Constants.ClaimTypes.Identifier).Value, out int id))
            {
                return new UserIdentity(id);
            }

            return null;
        }

        private static ClaimsIdentity GenerateClaimsIdentity(int id, string userName)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Constants.ClaimTypes.Identifier, id.ToString()),
                new Claim(Constants.ClaimTypes.Name, userName)
            });

            return identity;
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey)
        {
            return ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                ValidateLifetime = false // we check expired tokens here
            });
        }

        public ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters)
        {
            try
            {
                var principal = _jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}

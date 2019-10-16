using System;
using System.Threading.Tasks;
using MCB.Security.Auth.Models;
using MCB.Security.Auth.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCB.Security.Auth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        protected readonly ILoginRequestHandler _loginRequestHandler;
        protected readonly IRefreshTokenRequestHandler _refreshTokenRequestHandler;
        public AuthController(ILoginRequestHandler loginRequestHandler)
        {
            _loginRequestHandler = loginRequestHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Response response = await _loginRequestHandler.HandleAsync(new LoginRequest(user.UserName, user.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));

            return Ok(response);
        }

        [HttpPatch]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RefreshToken(string accessToken, string refreshToken)
        {
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
                return BadRequest("Missing token(s)");

            Response response = await _refreshTokenRequestHandler.HandleAsync(new RefreshTokenRequest(accessToken, refreshToken));

            return Ok(response);
        }
    }
}

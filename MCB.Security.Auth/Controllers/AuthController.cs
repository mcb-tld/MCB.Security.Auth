using System.Threading.Tasks;
using MCB.Security.Auth.Models;
using MCB.Security.Auth.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MCB.Security.Auth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        protected readonly ILoginRequestHandler _loginRequestHandler;
        public AuthController(ILoginRequestHandler loginRequestHandler)
        {
            _loginRequestHandler = loginRequestHandler;
        }

        public async Task<ActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Response response = await _loginRequestHandler.HandleAsync(new LoginRequest(user.UserName, user.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()));

            return Ok(response);
        }
    }
}

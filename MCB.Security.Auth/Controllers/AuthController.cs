using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCB.Security.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MCB.Security.Auth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        public async Task<ActionResult> Login(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return new EmptyResult();
        }
    }
}

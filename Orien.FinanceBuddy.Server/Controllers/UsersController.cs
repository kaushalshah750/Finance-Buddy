using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orien.FinanceBuddy.Business.Services;

namespace Orien.FinanceBuddy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        [HttpGet("authenticate")]
        public async Task<IActionResult> AuthenticateUser()
        {
            try
            {
                // Extract token from Authorization header
                var authHeader = HttpContext.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                    return Unauthorized("Authorization token missing or invalid");

                string token = authHeader.Substring(7); // Remove "Bearer " prefix

                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new[] { "156985885803-aqehd6sc7vfnkidaq1h4440dffoao55h.apps.googleusercontent.com" }
                };

                var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);

                if (payload == null)
                    return Unauthorized("Invalid Google token");

                return this.Ok(await this.userService.GetUserDetails(payload));
            }
            catch
            {
                return Unauthorized("Invalid token");
            }
        }

    }
}

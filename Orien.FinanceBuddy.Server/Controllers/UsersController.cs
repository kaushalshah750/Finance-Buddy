using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Orien.FinanceBuddy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [Authorize]
        [HttpPost("authenticate")]
        public string AuthenticateUser(string test)
        {
            return "authenticated";
        }

    }
}

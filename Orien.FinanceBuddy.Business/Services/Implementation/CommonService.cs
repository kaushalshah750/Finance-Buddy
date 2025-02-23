using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Orien.FinanceBuddy.Business.Services.Implementation
{
    public class CommonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetTokenFromHeader()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer "))
            {
                return token.Substring("Bearer ".Length).Trim();
            }

            return null;
        }

        public ClaimsPrincipal GetClaimsFromToken()
        {
            var token = GetTokenFromHeader();
            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return null;

            return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, "jwt"));
        }

        public string GetUserId()
        {
            var claims = GetClaimsFromToken();
            return claims?.FindFirst("sub")?.Value!;
        }
    }
}

using Orien.FinanceBuddy.Data.Entity;

namespace Orien.FinanceBuddy.Business.Services
{
    public interface IUserService
    {
        public Task<User> GetUserDetails(dynamic payload);
    }
}

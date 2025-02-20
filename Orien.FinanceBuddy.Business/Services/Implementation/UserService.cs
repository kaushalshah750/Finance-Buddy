using Google.Apis.Auth;
using Azure.Core;
using Orien.FinanceBuddy.Data.Entity;
using Orien.FinanceBuddy.Data;

namespace Orien.FinanceBuddy.Business.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly FinanceBuddyDbContext dbContext;

        public UserService(FinanceBuddyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetUserDetails(dynamic payload)
        {
            try
            {
                string subject = payload.Subject;

                var userExists = this.dbContext.Users.Where(x => x.Uid == subject).FirstOrDefault();

                if (userExists == null)
                {
                    User user = new User()
                    {
                        Uid = payload.Subject,
                        Name = payload.Name,
                        Email = payload.Email,
                        Picture = payload.Picture,
                        Last_Login = DateTime.Now,
                        Registered_on = DateTime.Now
                    };

                    await this.dbContext.Users.AddAsync(user);
                    await this.dbContext.SaveChangesAsync();
                    return user;
                }
                else
                {
                    userExists.Last_Login = DateTime.Now;
                    await this.dbContext.SaveChangesAsync();
                    return userExists;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

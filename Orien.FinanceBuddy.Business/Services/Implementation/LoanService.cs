using Microsoft.EntityFrameworkCore;
using Orien.FinanceBuddy.Business.Models;
using Orien.FinanceBuddy.Data;
using Orien.FinanceBuddy.Data.Entity;

namespace Orien.FinanceBuddy.Business.Services.Implementation
{
    public class LoanService : ILoanService
    {
        private readonly FinanceBuddyDbContext dbContext;

        public LoanService(FinanceBuddyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<LoanDTO>> GetLoans()
        {
            List<LoanDTO> loans = await this.dbContext.Loans.Select(x => new LoanDTO()
            {
                Id = x.Id,
                AddedBy_UId = this.dbContext.Users.Where(u => u.Uid == x.AddedBy_UId).First(),
                Amount = x.Amount,
                Bank = this.dbContext.Banks.Where(b => b.Id == x.Bank).First(),
                CreatedDate = x.CreatedDate,
                Monthly_Emi = x.Monthly_Emi,
                Name = x.Name,
                UpdatedDate = x.UpdatedDate,
            }).ToListAsync();

            return loans;
        }

        public async Task<List<Bank>> GetBanks()
        {
            return await this.dbContext.Banks.ToListAsync();
        }

        public async Task<bool> AddNewLoan(Loan loan, string userId)
        {
            try
            {
                loan.AddedBy_UId = userId;
                await this.dbContext.Loans.AddAsync(loan);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateLoan(Loan loan)
        {
            try
            {
                var loanData = await this.dbContext.Loans.Where(x => x.Id == loan.Id).FirstOrDefaultAsync();

                loanData.Monthly_Emi = loan.Monthly_Emi;
                loanData.Name = loan.Name;
                loanData.Bank = loan.Bank;
                loanData.Amount = loan.Amount;

                await this.dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public async Task<bool> DeleteLoan(long loanId)
        {
            try
            {
                var loan = await this.dbContext.Loans.Where(x => x.Id == loanId).FirstAsync();
                this.dbContext.Loans.Remove(loan);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

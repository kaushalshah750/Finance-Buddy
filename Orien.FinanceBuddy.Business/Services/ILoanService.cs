using Orien.FinanceBuddy.Business.Models;
using Orien.FinanceBuddy.Data.Entity;

namespace Orien.FinanceBuddy.Business.Services
{
    public interface ILoanService
    {
        Task<List<LoanDTO>> GetLoans();
        Task<List<Bank>> GetBanks();
        Task<bool> AddNewLoan(Loan loan, string userId);
        Task<bool> UpdateLoan(Loan loan);
        Task<bool> DeleteLoan(long loanId);
    }
}

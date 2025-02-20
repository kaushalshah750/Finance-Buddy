using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orien.FinanceBuddy.Data;
using Orien.FinanceBuddy.Data.Entity;
using System.Text.Json;

namespace Orien.FinanceBuddy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly FinanceBuddyDbContext dbContext;

        public LoansController(FinanceBuddyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Loan>> GetLoans()
        {
            return await this.dbContext.Loans.ToListAsync();
        }

        [HttpGet("banks")]
        public async Task<List<Bank>> GetBanks()
        {
            return await this.dbContext.Banks.ToListAsync();
        }

        [HttpPost("add")]
        public string AddNewLoan(Loan loan)
        {
            this.dbContext.Loans.Add(loan);
            this.dbContext.SaveChanges();
            return "Added";
        }

        [HttpPost("update")]
        public string UpdateLoan(Loan loan)
        {
            var loanData = this.dbContext.Loans.Where(x => x.Id == loan.Id).FirstOrDefault();

            loanData.Monthly_Emi = loan.Monthly_Emi;
            loanData.Name = loan.Name;
            loanData.Bank = loan.Bank;
            loanData.Amount = loan.Bank;

            this.dbContext.SaveChanges();
            return "Updated";
        }
    }
}

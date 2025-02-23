using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orien.FinanceBuddy.Business.Models;
using Orien.FinanceBuddy.Business.Services;
using Orien.FinanceBuddy.Business.Services.Implementation;
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
        private readonly ILoanService loanService;
        private readonly CommonService commonService;

        public LoansController(
            FinanceBuddyDbContext dbContext,
            ILoanService loanService,
            CommonService commonService)
        {
            this.dbContext = dbContext;
            this.loanService = loanService;
            this.commonService = commonService;
        }

        [HttpGet]
        public async Task<List<LoanDTO>> GetLoans()
        {
            return await this.loanService.GetLoans();
        }

        [HttpGet("banks")]
        public async Task<List<Bank>> GetBanks()
        {
            return await this.loanService.GetBanks();
        }

        [HttpPost("add")]
        public async Task<bool> AddNewLoan(Loan loan)
        {
            var userId = this.commonService.GetUserId();
            return await this.loanService.AddNewLoan(loan, userId);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateLoan(Loan loan)
        {
            return await this.loanService.UpdateLoan(loan);
        }

        [HttpDelete("delete/{loanId}")]
        public async Task<bool> DeleteLoan(long loanId)
        {
            return await this.loanService.DeleteLoan(loanId);
        }
    }
}

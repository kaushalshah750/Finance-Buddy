using Orien.FinanceBuddy.Data.Entity;

namespace Orien.FinanceBuddy.Business.Models
{
    public class LoanDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Bank Bank { get; set; }
        public decimal Amount { get; set; }
        public decimal Monthly_Emi { get; set; }
        public User AddedBy_UId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

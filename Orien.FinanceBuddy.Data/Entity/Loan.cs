using System;

namespace Orien.FinanceBuddy.Data.Entity
{
    public class Loan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Bank { get; set; }
        public decimal Amount { get; set; }
        public decimal Monthly_Emi { get; set; }
        public string AddedBy_UId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

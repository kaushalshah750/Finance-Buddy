using System;

namespace Orien.FinanceBuddy.Data.Entity
{
    public class Expense
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Period { get; set; }
        public string AddedBy_UId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

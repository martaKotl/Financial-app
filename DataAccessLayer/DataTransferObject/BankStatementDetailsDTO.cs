using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataTransferObject
{
    public class BankStatementDetailsDTO
    {
        public int BankStatementId { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int? RevenueSourcesId { get; set; }
        public string RevenueSourcesName { get; set; }
        public int? PurposeOfExpenseId { get; set; }
        public string PurposeOfExpenseName { get; set; }
        public string Flag { get; set; }
    }
}

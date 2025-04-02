using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataTransferObject;

namespace DataAccessLayer.DataTransferObject
{
    public class TransactionDTO
    {
        public List<BankDTO> Banks { get; set; }
        public List<RevenueSourceDTO> RevenueSources { get; set; }
        public List<PurposeOfExpenseDTO> PurposeOfExpenses { get; set; }

        public List<TransactionDetailsDTO> TranscationDetailsDTOs { get; set; }
    }
}

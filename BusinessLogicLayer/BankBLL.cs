using DataAccessLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataTransferObject;
using DataAccessLayer.DataAccessObject;

namespace BusinessLogicLayer
{
    public class BankBLL
    {
        public static void AddBank(BankDTO bank)
        {
            BankDAO.AddBank(bank);
        }

        public static void DeleteBank(int id)
        {
            BankDAO.DeleteBank(id);
        }

        public static List<BankDTO> GetBanks()
        {
            return BankDAO.GetBanks();
        }

        public static void UpdateBank(BankDTO bankDetails)
        {
            BankDAO.UpdateBank(bankDetails);
        }
    }
}

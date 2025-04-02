using DataAccessLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObject
{
    public class TransactionDAO
    {
        public static string[] filters = new string[6];

        public static void AddTransaction(TransactionDetailsDTO transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[TRANSACTION] ([DATE],[ID_BANK],[AMOUNT],[DESCRIPTION],[ID_PURPOSE_OF_EXPENSE],[ID_REVENUE_SOURCE],[ACCOUNT_BALANCE]) " +
                        "VALUES (@date, @bankId, @amount, @description, @purposeOfExpenseId, @revenueSourceId, @accountBalance)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", transaction.DateOfTransaction);
                        command.Parameters.AddWithValue("@bankId", transaction.BankId);
                        command.Parameters.AddWithValue("@amount", transaction.Amount);
                        command.Parameters.AddWithValue("@description", transaction.Description);
                        command.Parameters.AddWithValue("@accountBalance", transaction.AccountBalance);
                        if (transaction.Amount > 0)
                        {
                            command.Parameters.AddWithValue("@purposeOfExpenseId", DBNull.Value);
                            command.Parameters.AddWithValue("@revenueSourceId", transaction.RevenueSourcesId);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@purposeOfExpenseId", transaction.PurposeOfExpenseId);
                            command.Parameters.AddWithValue("@revenueSourceId", DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /*public static void CheckIfAccountBalanceNeedToBeChangeForFollowingTransactions(int transcationId, int id_bank, DateTime date)
        {
            List<TransactionDetailsDTO> transactionlist = new List<TransactionDetailsDTO>();
            transactionlist = TransactionDAO.GetTransactionsWithThisBankIdAndFromThisDate(id_bank, date);
            double accountBalance = 0;
            if (transactionlist.Count > 0) accountBalance = transactionlist.First().AccountBalance;
            bool firstItem = true;

            foreach (TransactionDetailsDTO transaction in transactionlist)
            {
                if (firstItem)
                {
                    firstItem = false;
                    continue;
                }

                if (accountBalance + transaction.Amount != transaction.AccountBalance)
                {
                    transaction.AccountBalance = accountBalance + transaction.Amount;
                    TransactionDAO.UpdateTransaction(transaction);
                    transactionlist = TransactionDAO.GetTransactionsWithThisBankIdAndFromThisDate(id_bank, date);
                }
                accountBalance += transaction.Amount;
            }
        }*/

        public static void DeleteTransaction(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[TRANSACTION] WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataView DisplayTransactionsInDataGridView(string fromDate, string toDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string Query = "SELECT [TRANSACTION].[ID], [DATE], [ID_BANK], [BANK].[NAME], [AMOUNT], [DESCRIPTION], [ID_PURPOSE_OF_EXPENSE], [PURPOSE_OF_EXPENSE].[NAME], [ID_REVENUE_SOURCE], [REVENUE_SOURCE].[NAME], [TRANSACTION].[ACCOUNT_BALANCE] FROM [dbo].[TRANSACTION]" +
               " JOIN Bank ON [TRANSACTION].ID_BANK = BANK.ID" +
               " LEFT JOIN PURPOSE_OF_EXPENSE ON ([TRANSACTION].ID_PURPOSE_OF_EXPENSE = PURPOSE_OF_EXPENSE.ID)" +
               " LEFT JOIN REVENUE_SOURCE ON ([TRANSACTION].[ID_REVENUE_SOURCE] = REVENUE_SOURCE.ID)" +
               " WHERE [TRANSACTION].[DATE] >= @FromDate AND [TRANSACTION].[DATE] <= @ToDate";

            if (!string.IsNullOrEmpty(filters[0]))
                Query += " AND [ID_BANK] = @bank";
            if (!string.IsNullOrEmpty(filters[1]) && string.IsNullOrEmpty(filters[2]))
                Query += " AND ([ID_REVENUE_SOURCE] = @revenueSource AND [ID_PURPOSE_OF_EXPENSE] IS NULL)";
            if (!string.IsNullOrEmpty(filters[2]) && string.IsNullOrEmpty(filters[1]))
                Query += " AND ([ID_PURPOSE_OF_EXPENSE] = @purposeOfExpanse AND [ID_REVENUE_SOURCE] IS NULL)";
            if (!string.IsNullOrEmpty(filters[1]) && !string.IsNullOrEmpty(filters[2]))
                Query += " AND ([ID_PURPOSE_OF_EXPENSE] = @purposeOfExpanse OR [ID_REVENUE_SOURCE] = @revenueSource)";
            if (!string.IsNullOrEmpty(filters[3]))
                Query += " AND [DESCRIPTION] LIKE @description";

            Query += " ORDER BY [TRANSACTION].[DATE]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@ToDate", toDate);
                        if (!string.IsNullOrEmpty(filters[0]))
                            cmd.Parameters.AddWithValue("@bank", filters[0]);
                        if (!string.IsNullOrEmpty(filters[1]))
                            cmd.Parameters.AddWithValue("@revenueSource", filters[1]);
                        if (!string.IsNullOrEmpty(filters[2]))
                            cmd.Parameters.AddWithValue("@purposeOfExpanse", filters[2]);
                        if (!string.IsNullOrEmpty(filters[3]))
                            cmd.Parameters.AddWithValue("@description", "%" + filters[3] + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet set = new DataSet();

                        adapter.Fill(set, "Items");
                        DataView dv = set.Tables["Items"].DefaultView;
                        return dv;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static TransactionDTO GetAll(DateTime transactionDateFrom, DateTime transactionDateTo)
        {
            TransactionDTO transactionList = new TransactionDTO();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            T.[ID] AS TransactionID, 
                            T.[DATE], 
                            B.[ID] AS BankID, 
                            B.[NAME] AS BankName, 
                            T.[AMOUNT], 
                            T.[DESCRIPTION], 
                            P.[ID] AS PurposeOfExpenseID, 
                            P.[NAME] AS PurposeOfExpenseName, 
                            R.[ID] AS RevenueSourceID, 
                            R.[NAME] AS RevenueSourceName, 
                            T.[ACCOUNT_BALANCE]
                        FROM [dbo].[TRANSACTION] AS T
                        LEFT JOIN [dbo].[BANK] AS B ON T.[ID_BANK] = B.[ID]
                        LEFT JOIN [dbo].[PURPOSE_OF_EXPENSE] AS P ON T.[ID_PURPOSE_OF_EXPENSE] = P.[ID]
                        LEFT JOIN [dbo].[REVENUE_SOURCE] AS R ON T.[ID_REVENUE_SOURCE] = R.[ID]
                        WHERE T.[DATE] >= @transactionDateFrom AND T.[DATE] <= @transactionDateTo
                        ORDER BY T.[DATE];";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@transactionDateFrom", transactionDateFrom);
                        command.Parameters.AddWithValue("@transactionDateTo", transactionDateTo);
                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Tymczasowe przechowywanie list dla DTO
                            List<BankDTO> banks = new List<BankDTO>();
                            List<RevenueSourceDTO> revenueSources = new List<RevenueSourceDTO>();
                            List<PurposeOfExpenseDTO> purposeOfExpenses = new List<PurposeOfExpenseDTO>();
                            List<TransactionDetailsDTO> transactionDetails = new List<TransactionDetailsDTO>();

                            while (reader.Read())
                            {
                                // Wypełnianie danych dla TransactionDetailsDTO
                                TransactionDetailsDTO transactionDetail = new TransactionDetailsDTO
                                {
                                    TranscationId = reader.GetInt32(0),
                                    DateOfTransaction = reader.GetDateTime(1),
                                    BankId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                    BankName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Amount = reader.GetDouble(4),
                                    Description = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    PurposeOfExpenseId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                    PurposeOfExpenseName = reader.IsDBNull(7) ? null : reader.GetString(7),
                                    RevenueSourcesId = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    RevenueSourcesName = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    AccountBalance = reader.GetDouble(10)
                                };

                                // Dodanie do listy szczegółów transakcji
                                transactionDetails.Add(transactionDetail);

                                // Wypełnianie danych dla BankDTO (unikalne)
                                if (transactionDetail.BankId > 0 &&
                                    !banks.Any(b => b.Id == transactionDetail.BankId))
                                {
                                    banks.Add(new BankDTO
                                    {
                                        Id = transactionDetail.BankId,
                                        Name = transactionDetail.BankName
                                    });
                                }
                                

                                // Wypełnianie danych dla RevenueSourceDTO (unikalne)
                                if (transactionDetail.RevenueSourcesId.HasValue &&
                                    !revenueSources.Any(r => r.Id == transactionDetail.RevenueSourcesId))
                                {
                                    revenueSources.Add(new RevenueSourceDTO
                                    {
                                        Id = transactionDetail.RevenueSourcesId.Value,
                                        Name = transactionDetail.RevenueSourcesName
                                    });
                                }

                                // Wypełnianie danych dla PurposeOfExpenseDTO (unikalne)
                                if (transactionDetail.PurposeOfExpenseId.HasValue &&
                                    !purposeOfExpenses.Any(p => p.Id == transactionDetail.PurposeOfExpenseId))
                                {
                                    purposeOfExpenses.Add(new PurposeOfExpenseDTO
                                    {
                                        Id = transactionDetail.PurposeOfExpenseId.Value,
                                        Name = transactionDetail.PurposeOfExpenseName
                                    });
                                }
                            }

                            transactionList.Banks = banks;
                            transactionList.RevenueSources = revenueSources;
                            transactionList.PurposeOfExpenses = purposeOfExpenses;
                            transactionList.TranscationDetailsDTOs = transactionDetails;
                        }
                    
                    }
                    return transactionList;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdateTransaction(TransactionDetailsDTO transaction)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[TRANSACTION] SET [DATE] = @date, [ID_BANK] = @bankId, [AMOUNT] = @amount, [DESCRIPTION] = @description, " +
                        "[ID_PURPOSE_OF_EXPENSE] = @purposeOfExpenseId, [ID_REVENUE_SOURCE] = @revenueSourceId, [ACCOUNT_BALANCE] = @accountBalance WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", transaction.TranscationId);
                        command.Parameters.AddWithValue("@date", transaction.DateOfTransaction);
                        command.Parameters.AddWithValue("@bankId", transaction.BankId);
                        command.Parameters.AddWithValue("@amount", transaction.Amount);
                        command.Parameters.AddWithValue("@description", transaction.Description);
                        command.Parameters.AddWithValue("@accountBalance", transaction.AccountBalance);
                        if (transaction.Amount > 0)
                        {
                            command.Parameters.AddWithValue("@revenueSourceId", transaction.RevenueSourcesId);
                            command.Parameters.AddWithValue("@purposeOfExpenseId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@purposeOfExpenseId", transaction.PurposeOfExpenseId);
                            command.Parameters.AddWithValue("@revenueSourceId", DBNull.Value);
                        }
                        
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

using DataAccessLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObject
{
    public class BankStatementDAO
    {
        public static void AddBankStatement(BankStatementDetailsDTO bankStatemant)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[BANK_STATEMENT] ([DATE],[ID_BANK],[AMOUNT],[DESCRIPTION],[ID_PURPOSE_OF_EXPENSE],[ID_REVENUE_SOURCE]) " +
                        "VALUES (@date, @bankId, @amount, @description, @purposeOfExpenseId, @revenueSourceId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", bankStatemant.DateOfTransaction);
                        command.Parameters.AddWithValue("@bankId", bankStatemant.BankId);
                        command.Parameters.AddWithValue("@amount", bankStatemant.Amount);
                        command.Parameters.AddWithValue("@description", bankStatemant.Description);
                        command.Parameters.AddWithValue("@purposeOfExpenseId", DBNull.Value);
                        command.Parameters.AddWithValue("@revenueSourceId", DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataView DisplayBankStatementAndTransactionsInDataGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string Query = "Select [BANK_STATEMENT].[ID],[DATE],[ID_BANK],[BANK].[NAME],[AMOUNT],[DESCRIPTION],[ID_PURPOSE_OF_EXPENSE],[PURPOSE_OF_EXPENSE].[NAME],[ID_REVENUE_SOURCE],[REVENUE_SOURCE].[NAME],'w' FLAG from [dbo].[BANK_STATEMENT]\n\r" +
                " Join BANK on BANK_STATEMENT.ID_BANK = BANK.ID\n\r" +
                "Left Join PURPOSE_OF_EXPENSE on(BANK_STATEMENT.ID_PURPOSE_OF_EXPENSE = PURPOSE_OF_EXPENSE.ID)\n\r" +
                "Left join REVENUE_SOURCE on(BANK_STATEMENT.ID_REVENUE_SOURCE = REVENUE_SOURCE.ID)\n\r" +
                "Union\n\r" +
                "Select[TRANSACTION].[ID],[DATE],[ID_BANK],[BANK].[NAME],[AMOUNT],[DESCRIPTION],[ID_PURPOSE_OF_EXPENSE],[PURPOSE_OF_EXPENSE].[NAME],[ID_REVENUE_SOURCE],[REVENUE_SOURCE].[NAME],'t' FLAG from[dbo].[TRANSACTION]\n\r" +
                "Join Bank on[TRANSACTION].ID_BANK = BANK.ID\n\r" +
                "Left Join PURPOSE_OF_EXPENSE on([TRANSACTION].ID_PURPOSE_OF_EXPENSE = PURPOSE_OF_EXPENSE.ID)\n\r" +
                "Left join REVENUE_SOURCE on([TRANSACTION].[ID_REVENUE_SOURCE] = REVENUE_SOURCE.ID)\n\r" +
                "where[TRANSACTION].[DATE] >= (select min([BANK_STATEMENT].[DATE]) from[BANK_STATEMENT]) AND[TRANSACTION].[DATE] <= (select max([BANK_STATEMENT].[DATE]) from[BANK_STATEMENT])\n\r" +
                "order by 2, AMOUNT";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                    DataSet set = new DataSet();

                    adapter.Fill(set, "Items");
                    DataView dv = set.Tables["Items"].DefaultView;
                    return dv;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static BankStatementDTO GetAll()
        {
            BankStatementDTO bankStatementList = new BankStatementDTO();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            S.[ID] AS BankStatementID, 
                            S.[DATE], 
                            B.[ID] AS BankID, 
                            B.[NAME] AS BankName, 
                            S.[AMOUNT], 
                            S.[DESCRIPTION], 
                            P.[ID] AS PurposeOfExpenseID, 
                            P.[NAME] AS PurposeOfExpenseName, 
                            R.[ID] AS RevenueSourceID, 
                            R.[NAME] AS RevenueSourceName
                        FROM [dbo].[BANK_STATEMENT] AS S
                        LEFT JOIN [dbo].[BANK] AS B ON S.[ID_BANK] = B.[ID]
                        LEFT JOIN [dbo].[PURPOSE_OF_EXPENSE] AS P ON S.[ID_PURPOSE_OF_EXPENSE] = P.[ID]
                        LEFT JOIN [dbo].[REVENUE_SOURCE] AS R ON S.[ID_REVENUE_SOURCE] = R.[ID]
                        ORDER BY S.[ID];";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Tymczasowe przechowywanie list dla DTO
                            List<BankDTO> banks = new List<BankDTO>();
                            List<RevenueSourceDTO> revenueSources = new List<RevenueSourceDTO>();
                            List<PurposeOfExpenseDTO> purposeOfExpenses = new List<PurposeOfExpenseDTO>();
                            List<BankStatementDetailsDTO> bankStatementDetails = new List<BankStatementDetailsDTO>();

                            while (reader.Read())
                            {
                                // Wypełnianie danych dla bankStatementDetailsDTO
                                BankStatementDetailsDTO bankStatementDetail = new BankStatementDetailsDTO
                                {
                                    BankStatementId = reader.GetInt32(0),
                                    DateOfTransaction = reader.GetDateTime(1),
                                    BankId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                    BankName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Amount = reader.GetDouble(4),
                                    Description = reader.IsDBNull(5) ? null : reader.GetString(5),
                                    PurposeOfExpenseId = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                    PurposeOfExpenseName = reader.IsDBNull(7) ? null : reader.GetString(7),
                                    RevenueSourcesId = reader.IsDBNull(8) ? (int?)null : reader.GetInt32(8),
                                    RevenueSourcesName = reader.IsDBNull(9) ? null : reader.GetString(9)
                                };

                                // Dodanie do listy szczegółów
                                bankStatementDetails.Add(bankStatementDetail);

                                // Wypełnianie danych dla BankDTO (unikalne)
                                if (bankStatementDetail.BankId > 0 &&
                                    !banks.Any(b => b.Id == bankStatementDetail.BankId))
                                {
                                    banks.Add(new BankDTO
                                    {
                                        Id = bankStatementDetail.BankId,
                                        Name = bankStatementDetail.BankName
                                    });
                                }


                                // Wypełnianie danych dla RevenueSourceDTO (unikalne)
                                if (bankStatementDetail.RevenueSourcesId.HasValue &&
                                    !revenueSources.Any(r => r.Id == bankStatementDetail.RevenueSourcesId))
                                {
                                    revenueSources.Add(new RevenueSourceDTO
                                    {
                                        Id = bankStatementDetail.RevenueSourcesId.Value,
                                        Name = bankStatementDetail.RevenueSourcesName
                                    });
                                }

                                // Wypełnianie danych dla PurposeOfExpenseDTO (unikalne)
                                if (bankStatementDetail.PurposeOfExpenseId.HasValue &&
                                    !purposeOfExpenses.Any(p => p.Id == bankStatementDetail.PurposeOfExpenseId))
                                {
                                    purposeOfExpenses.Add(new PurposeOfExpenseDTO
                                    {
                                        Id = bankStatementDetail.PurposeOfExpenseId.Value,
                                        Name = bankStatementDetail.PurposeOfExpenseName
                                    });
                                }
                            }

                            bankStatementList.Banks = banks;
                            bankStatementList.RevenueSources = revenueSources;
                            bankStatementList.PurposeOfExpenses = purposeOfExpenses;
                            bankStatementList.BankStatementDetailsDTOs = bankStatementDetails;
                        }
                    }
                    return bankStatementList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdateBankStatement(BankStatementDetailsDTO bankStatement)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[BANK_STATEMENT] SET [DATE] = @date, [ID_BANK] = @bankId, [AMOUNT] = @amount, [DESCRIPTION] = @description, " +
                        "[ID_PURPOSE_OF_EXPENSE] = @purposeOfExpenseId, [ID_REVENUE_SOURCE] = @revenueSourceId WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", bankStatement.BankStatementId);
                        command.Parameters.AddWithValue("@date", bankStatement.DateOfTransaction);
                        command.Parameters.AddWithValue("@bankId", bankStatement.BankId);
                        command.Parameters.AddWithValue("@amount", bankStatement.Amount);
                        command.Parameters.AddWithValue("@description", bankStatement.Description);
                        if (bankStatement.Amount > 0)
                        {
                            command.Parameters.AddWithValue("@revenueSourceId", bankStatement.RevenueSourcesId);
                            command.Parameters.AddWithValue("@purposeOfExpenseId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@purposeOfExpenseId", bankStatement.PurposeOfExpenseId);
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

        public void SaveDataToBankStatementDatabase()
        {
            string pathToStatement = System.Configuration.ConfigurationManager.AppSettings["PathToStatement"];

            using (StreamReader srBankStatement = new StreamReader(pathToStatement, System.Text.Encoding.Default))
            {
                int bankStatementId = 0;

                while (!srBankStatement.EndOfStream)
                {
                    string line = srBankStatement.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) break;

                    // Rozdziel linię na elementy
                    string[] tabBankStatement = line.Split(';');
                    if (tabBankStatement.Length < 5) continue; // Upewnij się, że dane są kompletne

                    // Obróbka danych
                    tabBankStatement[4] = tabBankStatement[4].TrimEnd(' ', 'P', 'L', 'N').Replace(",", ".");
                    tabBankStatement[1] = DeleteSpace(tabBankStatement[1].Trim('"'));
                    tabBankStatement[5] = bankStatementId.ToString();

                    SaveNewRecordFromTableToDataBase(tabBankStatement);
                    bankStatementId++;
                }
            }
        }
        public string DeleteSpace(string input)
        {
            // Usuwa wielokrotne spacje
            return Regex.Replace(input, @"\s{2,}", " ");
        }
        public void SaveNewRecordFromTableToDataBase(string[] tabBankStatement)
        {
            var bankStatement = new BankStatementDetailsDTO
            {
                DateOfTransaction = DateTime.Parse(tabBankStatement[0]),
                Description = tabBankStatement[1],
                Amount = double.Parse(tabBankStatement[4], CultureInfo.InvariantCulture),
                BankStatementId = int.Parse(tabBankStatement[5])
            };

            string pathToBankId = System.Configuration.ConfigurationManager.AppSettings["PathToBankId"];

            using (StreamReader srBankStatementId = new StreamReader(pathToBankId))
            {
                bankStatement.BankId = int.Parse(srBankStatementId.ReadLine());
            }

            BankStatementDAO.AddBankStatement(bankStatement);
        }

        public static void AddBankStatementToTransaction()
        {
            BankStatementDTO bankStatement = new BankStatementDTO();
            bankStatement = BankStatementDAO.GetAll();

            foreach (var item in bankStatement.BankStatementDetailsDTOs)
            {
                TransactionDetailsDTO transaction = new TransactionDetailsDTO();
                transaction.DateOfTransaction = item.DateOfTransaction;
                transaction.BankId = item.BankId;
                transaction.Amount = item.Amount;
                transaction.RevenueSourcesId = item.RevenueSourcesId != null ? (int?)item.RevenueSourcesId : null;
                transaction.PurposeOfExpenseId = item.PurposeOfExpenseId != null ? (int?)item.PurposeOfExpenseId : null;
                transaction.Description = item.Description;
                transaction.AccountBalance = 0;//TransactionBLL.CountAccountBalanceForTransaction(transaction.ID, transaction.ID_BANK, transaction.AMOUNT, transaction.DATE);
                TransactionDAO.AddTransaction(transaction);
                //TransactionDAO.CheckIfAccountBalanceNeedToBeChangeForFollowingTransactions(transaction.ID, transaction.ID_BANK, transaction.DATE);

            }
        }

        public static void DeleteAllRecordFromBankStatement()
        {
            BankStatementDTO bankStatement = new BankStatementDTO();
            bankStatement = BankStatementDAO.GetAll();

            foreach (var item in bankStatement.BankStatementDetailsDTOs)
            {
                BankStatementDAO.DeleteBankStatement(item.BankStatementId);
            }
        }

        public static void DeleteBankStatement(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[BANK_STATEMENT] WHERE [ID] = @id";
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
    }
}

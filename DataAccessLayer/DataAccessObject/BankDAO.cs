using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataTransferObject;

namespace DataAccessLayer.DataAccessObject
{
    public class BankDAO
    {
        public static void AddBank(BankDTO bank)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[BANK] ([ID],[NAME]) VALUES (@id, @name)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", bank.Id);
                        command.Parameters.AddWithValue("@name", bank.Name);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void DeleteBank(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[BANK] WHERE [ID] = @id";
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

        public static void UpdateBank(BankDTO bank)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[BANK] SET [NAME] = @name WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", bank.Id);
                        command.Parameters.AddWithValue("@name", bank.Name);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static List<BankDTO> GetBanks()
        {
            List<BankDTO> bankList = new List<BankDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT [ID], [NAME] FROM [dbo].[BANK]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BankDTO bank = new BankDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                };
                                bankList.Add(bank);
                            }
                        }
                    }

                    return bankList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

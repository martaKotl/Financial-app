using DataAccessLayer.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccessObject
{
    public class PurposeOfExpenseDAO
    {
        public static void AddPurposeOfExpense(PurposeOfExpenseDTO purposeOfExpense)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[PURPOSE_OF_EXPENSE] ([ID],[NAME],[IS_VISIBLE],[DISPLAY_ORDER]) VALUES (@id, @name, @isVisible, @displayOrder)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", purposeOfExpense.Id);
                        command.Parameters.AddWithValue("@name", purposeOfExpense.Name);
                        command.Parameters.AddWithValue("@displayOrder", purposeOfExpense.DisplayOrder);
                        command.Parameters.AddWithValue("@isVisible", purposeOfExpense.IsVisible);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void DeletePurposeOfExpense(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[PURPOSE_OF_EXPENSE] WHERE [ID] = @id";
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

        public static List<PurposeOfExpenseDTO> GetPurposeOfExpense()
        {
            List<PurposeOfExpenseDTO> purposeOfExpenseList = new List<PurposeOfExpenseDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT [ID], [NAME], [IS_VISIBLE], [DISPLAY_ORDER] FROM [dbo].[PURPOSE_OF_EXPENSE]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PurposeOfExpenseDTO purposeOfExpense = new PurposeOfExpenseDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    IsVisible = reader.GetBoolean(2),
                                    DisplayOrder = reader.GetInt32(3)
                                };
                                purposeOfExpenseList.Add(purposeOfExpense);
                            }
                        }
                    }

                    return purposeOfExpenseList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdatePurposeOfExpense(PurposeOfExpenseDTO purposeOfExpense)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[PURPOSE_OF_EXPENSE] SET [NAME] = @name, [IS_VISIBLE] = @isVisible, [DISPLAY_ORDER] = @displayOrder WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", purposeOfExpense.Id);
                        command.Parameters.AddWithValue("@name", purposeOfExpense.Name);
                        command.Parameters.AddWithValue("@isVisible", purposeOfExpense.IsVisible);
                        command.Parameters.AddWithValue("@displayOrder", purposeOfExpense.DisplayOrder);
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

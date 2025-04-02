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
    public class RevenueSourceDAO
    {
        public static void AddRevenueSource(RevenueSourceDTO revenueSource)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO [dbo].[REVENUE_SOURCE] ([ID],[NAME],[IS_VISIBLE],[DISPLAY_ORDER]) VALUES (@id, @name, @isVisible, @displayOrder)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", revenueSource.Id);
                        command.Parameters.AddWithValue("@name", revenueSource.Name);
                        command.Parameters.AddWithValue("@displayOrder", revenueSource.DisplayOrder);
                        command.Parameters.AddWithValue("@isVisible", revenueSource.IsVisible);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void DeleteRevenueSource(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[REVENUE_SOURCE] WHERE [ID] = @id";
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

        public static List<RevenueSourceDTO> GetRevenueSources()
        {
            List<RevenueSourceDTO> revenueSourceList = new List<RevenueSourceDTO>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT [ID], [NAME], [IS_VISIBLE], [DISPLAY_ORDER] FROM [dbo].[REVENUE_SOURCE]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RevenueSourceDTO revenueSource = new RevenueSourceDTO
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    IsVisible = reader.GetBoolean(2),
                                    DisplayOrder = reader.GetInt32(3)
                                };
                                revenueSourceList.Add(revenueSource);
                            }
                        }
                    }

                    return revenueSourceList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void UpdateRevenueSource(RevenueSourceDTO revenueSource)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[REVENUE_SOURCE] SET [NAME] = @name, [IS_VISIBLE] = @isVisible, [DISPLAY_ORDER] = @displayOrder WHERE [ID] = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", revenueSource.Id);
                        command.Parameters.AddWithValue("@name", revenueSource.Name);
                        command.Parameters.AddWithValue("@isVisible", revenueSource.IsVisible);
                        command.Parameters.AddWithValue("@displayOrder", revenueSource.DisplayOrder);
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

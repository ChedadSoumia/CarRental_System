using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsCustomersData
    {
        public static bool GetCustomerByID(int CustomerID, ref int PersonID,ref string NationalNo,ref string DriverLicenseNumber)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_GetCustomerByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerId", CustomerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Process results
                            while (reader.Read())
                            {
                                isFound = true;
                                PersonID = (int)reader["PersonID"];
                                NationalNo = (string)reader["NationalNo"];
                                DriverLicenseNumber = (string)reader["DriverLicenseNumber"];

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLog.LogError("",ex);
                return false;
            }

            return isFound;
        }
        public static bool GetCustomerByNationalNo(ref int CustomerID, ref int PersonID, string NationalNo, ref string DriverLicenseNumber)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_GetCustomerInfoByNationalNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@National_no", CustomerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Process results
                            while (reader.Read())
                            {
                                isFound = true;
                                CustomerID = (int)reader["CustomerID"];
                                PersonID = (int)reader["PersonID"];
                                DriverLicenseNumber = (string)reader["DriverLicenseNumber"];

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.LogError("", ex);
                return false;
            }

            return isFound;
        }


        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_GetAllCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return dt;
        }

        public static int AddNewCustomer(int PersonID, string NationalNo, string DriverLicenseNumber)
        {
            int CustomerID = -1;

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_AddNewCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Person_id", PersonID);
                        command.Parameters.AddWithValue("@National_no", NationalNo);
                        command.Parameters.AddWithValue("@Driver_license_number", DriverLicenseNumber);

                        SqlParameter outputIdParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        CustomerID = (int)command.Parameters["@CustomerID"].Value;
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.LogError("", ex);
            }




            return CustomerID;
        }

        public static bool UpdateCustomer(int CustomerID, int PersonID, string NationalNo, string DriverLicenseNumber)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_UpdateCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@@Person_id", PersonID);
                        command.Parameters.AddWithValue("@National_no", NationalNo);
                        command.Parameters.AddWithValue("@Driver_license_number", DriverLicenseNumber);


                        rowsAffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex) {
                clsEventLog.LogError("", ex);
                return false; 
            }

            return (rowsAffected > 0);
        }

        public static bool IsCustomerExist(int CustomerID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_CheckCustomerExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        command.ExecuteNonQuery();

                        int result = (int)returnParameter.Value;


                        return (result == 1);
                    }

                }
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_DeleteCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerID", CustomerID);


                        rowsAffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLog.LogError("", ex);
                return false;
            }
            return (rowsAffected > 0);

        }

    }
}

using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CarRental_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string FirstName,
           ref string LastName,ref string Phone, ref string Email, 
           ref short Gendor, ref string ImagePath)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
            using( SqlCommand command = new SqlCommand("spu_GetPersonByID", connection)){

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Person_id", PersonID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;

                            FirstName = (string)reader["FirstName"];



                            LastName = (string)reader["LastName"];
                            

                            if (reader["Phone"] != DBNull.Value)
                            {
                                Phone = (string)reader["Phone"];
                            }
                            else
                            {
                                Phone = null;
                            }

                            if (reader["Email"] != DBNull.Value)
                            {
                                Email = (string)reader["Email"];
                            }
                            else
                            {
                                Email = null;
                            }
                            Gendor = Convert.ToInt16(reader["Gender"]);

                            if (reader["ImagePath"] != DBNull.Value)
                            {
                                ImagePath = (string)reader["ImagePath"];
                            }
                            else
                            {
                                ImagePath = null;
                            }

                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);

                        isFound = false;
                    }

                }
            }

            return isFound;
        }





        public static int AddNewPerson( string FirstName,
            string LastName,  string Phone,  string Email,
            short Gendor,  string ImagePath)
        {
            int PersonID = -1;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("spu_AddNewPerson", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Person_Firstname", FirstName);



                    command.Parameters.AddWithValue("@Person_Lastname", LastName);
                    command.Parameters.AddWithValue("@Person_Gender", Gendor);

                    if (Phone != "" && Phone != null)
                        command.Parameters.AddWithValue("@Person_Phone", Phone);
                    else
                        command.Parameters.AddWithValue("@Person_Phone", System.DBNull.Value);

                    if (Email != "" && Email != null)
                        command.Parameters.AddWithValue("@Person_Email", Email);
                    else
                        command.Parameters.AddWithValue("@Person_Email", System.DBNull.Value);


                    if (ImagePath != "" && ImagePath != null)
                        command.Parameters.AddWithValue("@Person_Imagepath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@Person_Imagepath", System.DBNull.Value);

                    try
                    {
                        

                        SqlParameter outputIdParam = new SqlParameter("@Person_id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);


                        // Execute
                        command.ExecuteNonQuery();


                        // Retrieve the ID of the new person
                        PersonID = Convert.ToInt32(command.Parameters["@Person_id"].Value);
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);

                    }
                }
            }

            return PersonID;
        }



        public static bool UpdatePerson(int PersonID,string FirstName,
            string LastName, string Phone, string Email,
            short Gendor, string ImagePath)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spu_UpdatePerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Person_id", PersonID);
                    command.Parameters.AddWithValue("@Person_Firstname", FirstName);



                    command.Parameters.AddWithValue("@Person_Lastname", LastName);
                    command.Parameters.AddWithValue("@Person_Gender", Gendor);


                    if (Phone != "" && Phone != null)
                        command.Parameters.AddWithValue("@Person_Phone", Phone);
                    else
                        command.Parameters.AddWithValue("@Person_Phone", System.DBNull.Value);

                    if (Email != "" && Email != null)
                        command.Parameters.AddWithValue("@Person_Email", Email);
                    else
                        command.Parameters.AddWithValue("@Person_Email", System.DBNull.Value);


                    if (ImagePath != "" && ImagePath != null)
                        command.Parameters.AddWithValue("@Person_Imagepath", ImagePath);
                    else
                        command.Parameters.AddWithValue("@Person_Imagepath", System.DBNull.Value);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }


            return (rowsAffected > 0);
        }


        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_GetAllPeople", connection))
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

        

        public static bool DeletePerson(int PersonID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete FROM People 
                                where Person_id = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsPersonExist(int PersonID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_CheckPersonExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Person_ID", PersonID);

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

        public static bool IsEmailExist(string Email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("spu_CheckPersonExistsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Email", Email);

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



        


    }
}

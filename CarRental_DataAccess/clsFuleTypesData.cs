using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsFuleTypesData
    {
        public static bool GetFuelTypeByID(int FuelTypeID, ref string FuelTypeName)
        {
            bool IsFound = false;

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                         FROM FuleTypes
                         WHERE FuelTypeID = @FuelTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    FuelTypeName = (string)Reader["FuelTypeName"];
                }

                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool GetFuelTypeByName(string FuelTypeName, ref int FuelTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                         FROM FuleTypes
                         WHERE FuelTypeName = @FuelTypeName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;

                    FuelTypeID = (int)Reader["FuelTypeID"];
                }

                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllFuleTypes()
        {
            DataTable DT = new DataTable();

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                         FROM FuleTypes
                         ORDER BY FuelTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    DT.Load(Reader);

                Reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return DT;
        }

        public static int AddNewFuelType(string FuelTypeName)
        {
            int FuelTypeID = -1;

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
        INSERT INTO FuleTypes (FuelTypeName)
        VALUES (@FuelTypeName);

        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null &&
                    int.TryParse(Result.ToString(), out int InsertedID))
                {
                    FuelTypeID = InsertedID;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return FuelTypeID;
        }

        public static bool UpdateFuelType(int FuelTypeID, string FuelTypeName)
        {
            bool IsUpdated = false;

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE FuleTypes
                         SET FuelTypeName = @FuelTypeName
                         WHERE FuelTypeID = @FuelTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            Command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

            try
            {
                Connection.Open();

                IsUpdated = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsUpdated;
        }

        public static bool DeleteFuelType(int FuelTypeID)
        {
            bool IsDeleted = false;

            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM FuleTypes
                         WHERE FuelTypeID = @FuelTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);

            try
            {
                Connection.Open();

                IsDeleted = Command.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsDeleted;
        }

        public static bool IsFuelTypeExist(int FuelTypeID)
        {
            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Found = 1
                         FROM FuleTypes
                         WHERE FuelTypeID = @FuelTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                return Result != null;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }


        public static bool IsFuelTypeExist(string FuelTypeName)
        {
            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT Found = 1
                         FROM FuleTypes
                         WHERE FuelTypeName = @FuelTypeName";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FuelTypeName", FuelTypeName);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                return Result != null;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}

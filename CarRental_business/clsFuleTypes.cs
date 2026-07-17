using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_business
{
    public class clsFuleTypes
    {

        public enum enMode { eAddNew = 0, eUpdate = 1 };
        public enMode Mode = enMode.eAddNew;

        public int FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        public clsFuleTypes()
        {
            FuelTypeID = -1;
            FuelTypeName = "";
            Mode = enMode.eAddNew;
        }

        private clsFuleTypes(int fuelTypeID, string fuelTypeName)
        {
            FuelTypeID = fuelTypeID;
            FuelTypeName = fuelTypeName;

            Mode = enMode.eUpdate;
        }

        public static clsFuleTypes Find(int fuelTypeID)
        {
            string fuelTypeName = "";

            if (clsFuleTypesData.GetFuelTypeByID(fuelTypeID, ref fuelTypeName))
            {
                return new clsFuleTypes(fuelTypeID, fuelTypeName);
            }

            return null;
        }

        public static clsFuleTypes Find(string fuelTypeName)
        {
            int fuelTypeID = -1;

            if (clsFuleTypesData.GetFuelTypeByName(fuelTypeName, ref fuelTypeID))
            {
                return new clsFuleTypes(fuelTypeID, fuelTypeName);
            }

            return null;
        }

        public static bool IsFuelTypeExist(int fuelTypeID)
        {
            return clsFuleTypesData.IsFuelTypeExist(fuelTypeID);
        }
        public static bool IsFuelTypeExist(string fuelTypeName)
        {
            return clsFuleTypesData.IsFuelTypeExist(fuelTypeName);
        }

        private bool _AddNewFuleType()
        {
            FuelTypeID = clsFuleTypesData.AddNewFuelType(this.FuelTypeName);
            return (FuelTypeID != -1);
        }

        private bool _UpdateFuleType()
        {
            return clsFuleTypesData.UpdateFuelType(this.FuelTypeID, this.FuelTypeName);
        }

        public static DataTable GetAllFuelTypes()
        {
            return clsFuleTypesData.GetAllFuleTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewFuleType())
                    {

                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.eUpdate:

                    return _UpdateFuleType();

            }

            return false;
        }
    }
}

using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_business
{
    public class clsCustomers
    {

        public enum enMode { eAddNew = 1, eUpdate = 2 }
        public enMode Mode = enMode.eAddNew;

        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string NationalNo { get; set; }
        public string DriverLicenseNumber { get; set; }


        public clsCustomers()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.NationalNo = "";
            this.DriverLicenseNumber = "";
            Mode = enMode.eAddNew;
        }
        private clsCustomers(int customerID, int personID, string nationalNo, string driverLicenseNumber)
        {
            this.CustomerID = customerID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            this.NationalNo = nationalNo;
            this.DriverLicenseNumber = driverLicenseNumber;
            Mode = enMode.eUpdate;
        }
        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomersData.AddNewCustomer(this.PersonID, this.NationalNo, this.DriverLicenseNumber);
            return (this.CustomerID != -1);
        }
        private bool _UpdateCustomer()
        {

            return clsCustomersData.UpdateCustomer(this.CustomerID, this.PersonID, this.NationalNo, this.DriverLicenseNumber);
        }
        public static clsCustomers Find(int customerID)
        {
            int customerId = -1, PersonId = -1;
            string nationalNo = "", driverLicenseNumber = "";
            bool isFound = clsCustomersData.GetCustomerByID(customerID, ref PersonId, ref nationalNo, ref driverLicenseNumber);
            if (isFound)
            {
                return new clsCustomers(customerId, PersonId, nationalNo, driverLicenseNumber);
            }
            else
            {
                return null;
            }

        }
        public static clsCustomers Find(string nationalNo)
        {
            int customerID = -1,customerId = -1, PersonId = -1;
            string driverLicenseNumber = "";
            bool isFound = clsCustomersData.GetCustomerByNationalNo(ref customerID, ref PersonId, nationalNo, ref driverLicenseNumber);
            if (isFound)
            {
                return new clsCustomers(customerId, PersonId, nationalNo, driverLicenseNumber);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllCustomers()
        {
            return clsCustomersData.GetAllCustomers();
        }
        public static bool DeleteCustomer(int customerID)
        {
            return clsCustomersData.DeleteCustomer(customerID);
        }

        
        public static bool IsCustomerExistByID(int CustomerID)
        {
            return clsCustomersData.IsCustomerExist(CustomerID);
        }
        
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if(_AddNewCustomer())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdateCustomer();
            }
            return false;
        }
    }
}

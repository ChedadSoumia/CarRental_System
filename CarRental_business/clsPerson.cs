using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarRental_DataAccess;

namespace CarRental_business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
 
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " "  + LastName; }

        }
        public short Gendor { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }


        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()

        {
            this.PersonID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Phone = "";
            this.Email = "";
            this.Gendor = 0;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string FirstName,
            string LastName, string Phone, string Email, short Gendor, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Gendor = Gendor;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(
                this.FirstName,
                this.LastName,this.Phone, this.Email,
                 this.Gendor, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(
                this.PersonID, this.FirstName, this.LastName,  
                this.Phone, this.Email,
                this.Gendor, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {

            string FirstName = "",  LastName = "",  Email = "", Phone = "", ImagePath = "";
            
            short Gendor = 0;

            bool IsFound = clsPersonData.GetPersonInfoByID
                                (
                                    PersonID, ref FirstName, ref LastName,
                                   ref Phone, ref Email, ref Gendor , ref ImagePath
                                );

            if (IsFound)
                return new clsPerson(PersonID, FirstName, LastName,
                             Phone, Email, Gendor, ImagePath);
            else
                return null;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool isEmailExist(string Email)
        {
            return clsPersonData.IsEmailExist(Email);
        }

    }
}

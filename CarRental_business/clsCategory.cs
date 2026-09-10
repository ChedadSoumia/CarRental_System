using ERP_System_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System_Buisness
{
    public class clsCategory
    {

        public enum enMode { eAddNew =1 , eUpdate = 2}
        public enMode Mode = enMode.eAddNew;

        public int CategoryId {  get; set; }
        public string CategoryName { get; set; }

        public clsCategory()
        {
            CategoryId = -1;
            CategoryName = "";

            Mode = enMode.eAddNew;
        }
        public clsCategory(int categoryId, string categoryName)
        {
            CategoryId=categoryId;
            CategoryName=categoryName;

            Mode = enMode.eUpdate;
        }

        private bool _AddNewCategories()
        {
            this.CategoryId = clsCategoryData.AddNewCategories(this.CategoryName);
            return (this.CategoryId != -1);
        }
        private bool _UpdateCategory()
        {
            return clsCategoryData.UpdateCategory(this.CategoryId,this.CategoryName);
        }

        public static clsCategory Find(int CategoryID)
        {
            string categoryName = "";

            bool isFound = clsCategoryData.GetCategoryByID(CategoryID,ref categoryName);

            if (isFound)
            {
                return new clsCategory(CategoryID,categoryName);
            }
            else
            {
                return null;
            }

        }
        public static clsCategory Find(string categoryName)
        {
            int CategoryID = -1;

            bool isFound = clsCategoryData.GetCategoryByName(ref CategoryID, categoryName);

            if (isFound)
            {
                return new clsCategory(CategoryID,categoryName);
            }
            else
            {
                return null;
            }

        }


        public static DataTable GetAllCategories()
        {
            return clsCategoryData.GetAllCategories();
        }

        public static bool IsCategoryExist(string CategoryName)
        {
            return clsCategoryData.IsCategoryExist(CategoryName);
        }

        public static bool DeleteCategory(int CategoryID)
        {
            return clsCategoryData.DeleteCategory(CategoryID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewCategories())
                    {

                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.eUpdate:

                    return _UpdateCategory();

            }

            return false;
        }
    }
}

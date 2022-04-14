using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SV18T1021293.DataLayer;
using SV18T1021293.DomainModel;
namespace SV18T1021293.BusinessLayer
{
    /// <summary>
    /// Cung cấp các chức năng xử lý dữ liệu chung
    /// </summary>
    public static class CommonDataService
    {
        private static ICategoryDAL categoryDB;
        private static ICustomerDAL customerDB;
        /// <summary>
        /// Ctor
        /// </summary>
        static CommonDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            if (provider == "SQLServer")
            {
                categoryDB = new DataLayer.SQLServer.CategoryDAL(connectionString);
                customerDB = new DataLayer.SQLServer.CustomerDAL(connectionString);
            }
            else
            {
                categoryDB = new DataLayer.FakeDB.CategoryDAL();
            }
        }
        /// <summary>
        /// Lấy danh sách các mặt hàng
        /// </summary>
        /// <returns></returns>
        public static List<Category> ListOfCategories()
        {
            return categoryDB.List().ToList();
        }

        /// <summary>
        /// Tìm kiếm và danh sách khách hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers(int page, int pageSize, string searchValue, out int rowCount )
        {
            rowCount = customerDB.Count(searchValue);
            return customerDB.List(page, pageSize, searchValue).ToList();
        }
    }
}

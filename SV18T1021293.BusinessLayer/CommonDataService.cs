using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SV18T1021293.DataLayer;
using SV18T1021293.DomainModel;
using SV18T1021293.DataLayer.SQLServer;

namespace SV18T1021293.BusinessLayer
{
    /// <summary>
    /// Cung cấp các chức năng xử lý dữ liệu chung
    /// </summary>
    public static class CommonDataService
    {
        private static ICommonDAL<Category> categoryDB;
        private static ICommonDAL<Customer> customerDB;
        private static ICommonDAL<Supplier> supplierDB;
        private static ICommonDAL<Shipper> shipperDB;
        private static ICommonDAL<Employee> employeeDB;
        private static ICommonDAL<Country> countryDB;
        private static ProductDAL productDB;
        private static IProductPhotoDAL productPhotoDB;
        private static IProductAttribiteDAL productAtrributeDB;
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
                supplierDB = new DataLayer.SQLServer.SupplierDAL(connectionString);
                shipperDB = new DataLayer.SQLServer.ShipperDAL(connectionString);
                employeeDB = new DataLayer.SQLServer.EmployeeDAL(connectionString);
                countryDB = new DataLayer.SQLServer.CountryDAL(connectionString);
                productDB = new DataLayer.SQLServer.ProductDAL(connectionString);
                productPhotoDB = new DataLayer.SQLServer.ProductPhotoDAL(connectionString);
                productAtrributeDB = new DataLayer.SQLServer.ProductAttributeDAL(connectionString);
            }
        }
        /// <summary>
        /// Lấy danh sách các mặt hàng
        /// </summary>
        /// <returns></returns>
        public static List<Category> ListOfCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = categoryDB.Count(searchValue);
            return categoryDB.List(page,pageSize,searchValue).ToList();
        }

        /// <summary>
        /// 
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Customer> ListOfCustomers()
        {
            return customerDB.List().ToList();
        }

        /// <summary>
        /// Tìm Kiếm dánh sách nhà cung cấp dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers (int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = supplierDB.Count(searchValue);
            return supplierDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Supplier> ListOfSuppliers()
        {
            return supplierDB.List().ToList();
        }

        /// <summary>
        /// Tìm kiếm danh sách người giao hàng dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = shipperDB.Count(searchValue);
            return shipperDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Shipper> ListOfShippers()
        {
            return shipperDB.List().ToList();
        }

        /// <summary>
        /// Tìm kiếm danh sách nhân viên dưới dạng phân trang
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = employeeDB.Count(searchValue);
            return employeeDB.List(page, pageSize, searchValue).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Employee> ListOfEmployees()
        {
            return employeeDB.List().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListOfCountries()
        {
            return countryDB.List().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static List<Country> ListOfCountries(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = countryDB.Count(searchValue);
            return countryDB.List(page,pageSize,searchValue).ToList();
        }
        /// <summary>
        /// Tìm kiếm sản phẩn dưới dạng phân trang có và lọc theo loại hàng và nhà cung cấp
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="categoryID"></param>
        /// <param name="supplierID"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Product> ListOfProducts(int page, int pageSize, string searchValue, int categoryID, int supplierID, out int rowCount)
        {
            rowCount = productDB.Count(searchValue,categoryID,supplierID);
            return productDB.List(page,pageSize,searchValue,categoryID,supplierID).ToList();
        }

        public static List<Product> ListOfProducts()
        {
            return productDB.List(1,0,"",0,0).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return customerDB.Add(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return customerDB.Update(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerID)
        {
            if (customerDB.InUsed(customerID))
                return false;
            return customerDB.Delete(customerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerID)
        {
            return customerDB.Get(customerID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool InUsedCustomer(int customerID)
        {
            return customerDB.InUsed(customerID);
        }



        /// <summary>
        /// Thêm mới nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return supplierDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier (Supplier data)
        {
            return supplierDB.Update(data);
        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            if (supplierDB.InUsed(supplierID))
                return false;
            return supplierDB.Delete(supplierID);
        }
        /// <summary>
        /// lấy thông tin 1 nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return supplierDB.Get(supplierID);
        }
        /// <summary>
        /// kiểm tra xem nhà cung cấp có dữ liệu liên quan
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool InUsedSupplier(int supplierID)
        {
            return supplierDB.InUsed(supplierID);
        }



        /// <summary>
        /// Thêm mới người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return shipperDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin Người giao hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return shipperDB.Update(data);
        }
        /// <summary>
        /// Xóa người giao hàng
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperID)
        {
            if (shipperDB.InUsed(shipperID))
                return false;
            return shipperDB.Delete(shipperID);
        }
        /// <summary>
        /// lấy thông tin 1 người giao hàng
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperID)
        {
            return shipperDB.Get(shipperID);
        }
        /// <summary>
        /// kiểm tra xem nhà cung cấp có dữ liệu liên quan
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUsedShipper(int shipperID)
        {
            return shipperDB.InUsed(shipperID);
        }


        /// <summary>
        /// Thêm mới loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return categoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return categoryDB.Update(data);
        }
        /// <summary>
        /// Xóa loại hàng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryID)
        {
            if (categoryDB.InUsed(categoryID))
                return false;
            return categoryDB.Delete(categoryID);
        }
        /// <summary>
        /// lấy thông tin 1 loại hàng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryID)
        {
            return categoryDB.Get(categoryID);
        }
        /// <summary>
        /// kiểm tra xem loại hàng có dữ liệu liên quan
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        public static bool InUsedCategory(int categoryID)
        {
            return categoryDB.InUsed(categoryID);
        }


        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return employeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return employeeDB.Update(data);
        }
        /// <summary>
        /// Xóa loại nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeID)
        {
            if (employeeDB.InUsed(employeeID))
                return false;
            return employeeDB.Delete(employeeID);
        }
        /// <summary>
        /// lấy thông tin 1 nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeID)
        {
            return employeeDB.Get(employeeID);
        }
        /// <summary>
        /// kiểm tra xem nhân viên có dữ liệu liên quan
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool InUsedEmployee(int employeeID)
        {
            return employeeDB.InUsed(employeeID);
        }



        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddProduct(Product data)
        {
            return productDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProduct(Product data)
        {
            return productDB.Update(data);
        }
        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool DeleteProduct(int productID)
        {
            if (productDB.InUsed(productID))
                return false;
            return productDB.Delete(productID);
        }
        /// <summary>
        /// lấy thông tin 1 sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static Product GetProduct(int productID)
        {
            return productDB.Get(productID);
        }
        /// <summary>
        /// kiểm tra xem sản phẩm có dữ liệu liên quan
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool InUsedProduct(int productID)
        {
            return productDB.InUsed(productID);
        }



        /// <summary>
        /// Thêm mới 1 ảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddProductPhoto(ProductPhoto data)
        {
            return productPhotoDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin 1 ảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProductPhoto(ProductPhoto data)
        {
            return productPhotoDB.Update(data);
        }
        /// <summary>
        /// Xóa 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        public static bool DeleteProductPhoto(int photoID)
        {
            return productPhotoDB.Delete(photoID);
        }
        /// <summary>
        /// lấy thông tin 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        public static ProductPhoto GetProductPhoto(int photoID)
        {
            return productPhotoDB.Get(photoID);
        }
        /// <summary>
        /// Lấy danh sách ảnh của 1 sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static List<ProductPhoto> ListOfProductPhotos(int productID)
        {
            return productPhotoDB.List(productID).ToList();
        }



        /// <summary>
        /// Thêm mới 1 thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddProductAttribute(ProductAttribute data)
        {
            return productAtrributeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật thông tin 1 thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProductAttribute(ProductAttribute data)
        {
            return productAtrributeDB.Update(data);
        }
        /// <summary>
        /// Xóa 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public static bool DeleteProductAttribute(int attributeID)
        {
            return productAtrributeDB.Delete(attributeID);
        }
        /// <summary>
        /// lấy thông tin 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public static ProductAttribute GetProductAttribute(int attributeID)
        {
            return productAtrributeDB.Get(attributeID);
        }
        /// <summary>
        /// Lấy danh sách thuộc tính của 1 sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static List<ProductAttribute> ListOfProductAttributes(int productID)
        {
            return productAtrributeDB.List(productID).ToList();
        }
    }
}

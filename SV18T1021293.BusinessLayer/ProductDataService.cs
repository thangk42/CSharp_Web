using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DataLayer;
using SV18T1021293.DataLayer.SQLServer;
using SV18T1021293.DomainModel;

namespace SV18T1021293.BusinessLayer
{
    public static class ProductDataService
    {
        private static IProductDAL productDB;

        static ProductDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            if (provider == "SQLServer")
            {
                productDB = new DataLayer.SQLServer.ProductDAL(connectionString);
            }
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
            rowCount = productDB.Count(searchValue, categoryID, supplierID);
            return productDB.List(page, pageSize, searchValue, categoryID, supplierID).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Product> ListOfProducts()
        {
            return productDB.List(1, 0, "", 0, 0).ToList();
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
            return productDB.AddPhoto(data);
        }
        /// <summary>
        /// Cập nhật thông tin 1 ảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProductPhoto(ProductPhoto data)
        {
            return productDB.UpdatePhoto(data);
        }
        /// <summary>
        /// Xóa 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        public static bool DeleteProductPhoto(int photoID)
        {
            return productDB.DeletePhoto(photoID);
        }
        /// <summary>
        /// lấy thông tin 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        public static ProductPhoto GetProductPhoto(int photoID)
        {
            return productDB.GetPhoto(photoID);
        }
        /// <summary>
        /// Lấy danh sách ảnh của 1 sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static List<ProductPhoto> ListOfProductPhotos(int productID)
        {
            return productDB.ListPhoto(productID).ToList();
        }

        /// <summary>
        /// Thêm mới 1 thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddProductAttribute(ProductAttribute data)
        {
            return productDB.AddAttribute(data);
        }
        /// <summary>
        /// Cập nhật thông tin 1 thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateProductAttribute(ProductAttribute data)
        {
            return productDB.UpdateAttribute(data);
        }
        /// <summary>
        /// Xóa 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public static bool DeleteProductAttribute(int attributeID)
        {
            return productDB.DeleteAttribute(attributeID);
        }
        /// <summary>
        /// lấy thông tin 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        public static ProductAttribute GetProductAttribute(int attributeID)
        {
            return productDB.GetAttribute(attributeID);
        }
        /// <summary>
        /// Lấy danh sách thuộc tính của 1 sản phẩm
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static List<ProductAttribute> ListOfProductAttributes(int productID)
        {
            return productDB.ListAttribute(productID).ToList();
        }
    }
}

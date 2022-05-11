using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer.SQLServer
{
    /// <summary>
    /// Định nghĩa các phép xử lý liên quan đến sản phẩm
    /// </summary>
    public interface IProductDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Product data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        int Count(string searchValue, int categoryID, int supplierID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool Delete(int productID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product Get(int productID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        bool InUsed(int productID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        IList<Product> List(int page, int pageSize, string searchValue, int categoryID, int supplierID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Product data);
        /// <summary>
        /// lấy dánh sách thuộc tính theo ProductID
        /// </summary>
        /// <param name="productID">Trang cần xem</param>
        /// <returns></returns>
        IList<ProductAttribute> ListAttribute(int productID);

        /// <summary>
        /// Lấy thông tin của 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        ProductAttribute GetAttribute(int attributeID);

        /// <summary>
        /// Bổ sung một thuộc tính. Hàm trả về mã thuộc tính được bô sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int AddAttribute(ProductAttribute data);
        /// <summary>
        /// Cập nhật thông tin thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdateAttribute(ProductAttribute data);
        /// <summary>
        /// Xóa thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        bool DeleteAttribute(int attributeID);

        /// <summary>
        /// lấy dánh sách ảnh theo ProductID
        /// </summary>
        /// <param name="productID">Trang cần xem</param>
        /// <returns></returns>
        IList<ProductPhoto> ListPhoto(int productID);

        /// <summary>
        /// Lấy thông tin của 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        ProductPhoto GetPhoto(int photoID);

        /// <summary>
        /// Bổ sung một ảnh. Hàm trả về mã ảnh được bô sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int AddPhoto(ProductPhoto data);
        /// <summary>
        /// Cập nhật thông tin ảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool UpdatePhoto(ProductPhoto data);
        /// <summary>
        /// Xóa ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        bool DeletePhoto(int photoID);
    }
}

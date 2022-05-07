using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến Thư viện ảnh
    /// </summary>
    public interface IProductPhotoDAL
    {
        /// <summary>
        /// lấy dánh sách ảnh theo ProductID
        /// </summary>
        /// <param name="productID">Trang cần xem</param>
        /// <returns></returns>
        IList<ProductPhoto> List(int productID);

        /// <summary>
        /// Lấy thông tin của 1 ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        ProductPhoto Get(int photoID);

        /// <summary>
        /// Bổ sung một ảnh. Hàm trả về mã ảnh được bô sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(ProductPhoto data);
        /// <summary>
        /// Cập nhật thông tin ảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(ProductPhoto data);
        /// <summary>
        /// Xóa ảnh
        /// </summary>
        /// <param name="photoID"></param>
        /// <returns></returns>
        bool Delete(int photoID);
    }
}

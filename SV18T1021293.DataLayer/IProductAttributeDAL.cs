using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer.SQLServer
{ /// <summary>
  /// Định nghĩa các phép xử lý dữ liệu liên quan đến thuộc tính sản phẩm
  /// </summary>
    public interface IProductAttribiteDAL
    {
        /// <summary>
        /// lấy dánh sách thuộc tính theo ProductID
        /// </summary>
        /// <param name="productID">Trang cần xem</param>
        /// <returns></returns>
        IList<ProductAttribute> List(int productID);

        /// <summary>
        /// Lấy thông tin của 1 thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        ProductAttribute Get(int attributeID);

        /// <summary>
        /// Bổ sung một thuộc tính. Hàm trả về mã thuộc tính được bô sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(ProductAttribute data);
        /// <summary>
        /// Cập nhật thông tin thuộc tính
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(ProductAttribute data);
        /// <summary>
        /// Xóa thuộc tính
        /// </summary>
        /// <param name="attributeID"></param>
        /// <returns></returns>
        bool Delete(int attributeID);
    }
}

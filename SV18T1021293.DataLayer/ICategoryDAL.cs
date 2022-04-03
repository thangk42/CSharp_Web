using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;

namespace SV18T1021293.DataLayer
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến loại hàng
    /// </summary>
    public interface ICategoryDAL
    {
        /// <summary>
        /// Lấy danh sách loại hàng
        /// </summary>
        /// <returns></returns>
        IList<Category> List();
        /// <summary>
        /// Lấy thông tin 1 loại hàng dựa vào mã loại hàng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        Category Get(int categoryID);

        /// <summary>
        /// Bổ sung một loại hàng mới. Hàm trả về mẽ của loại hàng được bổ sung
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Category data);
        /// <summary>
        /// Cập nhật thông tin của một loại hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Update(Category data);
        /// <summary>
        /// Xóa một loại hàng dựa vào mã loại hàng.
        /// Lưu ý: không xóa nếu loại hàng đã được sử dụng
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        bool Delete(int categoryID);
    }
}

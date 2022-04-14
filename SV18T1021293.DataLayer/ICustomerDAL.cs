using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SV18T1021293.DomainModel;
namespace SV18T1021293.DataLayer
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến khách hàng
    /// </summary>
    public interface ICustomerDAL
    {
        /// <summary>
        /// Tìm kiếm và lấy dánh sách khách hàng dưới dạng phân trang 
        /// </summary>
        /// <param name="page">Trang cần xem</param>
        /// <param name="pagesize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Tên hoặc địa chỉ cần tìm (tương đối) .(nếu là chuỗi rỗng thì lấy toàn bộ dũ liệu)</param>
        /// <returns></returns>
        IList<Customer> List(int page, int pageSize, string searchValue);

        /// <summary>
        /// Đếm số lượng khách hàng thỏa điều kiện 
        /// </summary>
        /// <param name="searchValue">Tên hoặc địa chỉ cần tìm (tương đối) .(nếu là chuỗi rỗng thì lấy toàn bộ dũ liệu)</param>
        /// <returns></returns>
        int Count(string searchValue);

        /// <summary>
        /// Lấy thông tin của 1 khách hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        Customer Get(int customerID);

        /// <summary>
        /// Bổ sung một khách hàng. Hàm trả về mã khách hàng được bô sungs
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int Add(Customer data);
        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Customer data);
        /// <summary>
        /// Xóa khách hàng 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool Delete(int customerID);

        /// <summary>
        /// Kiểm tra khách hàng có dữ liệu liên quan
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool InUsed(int customerID);
    }
}

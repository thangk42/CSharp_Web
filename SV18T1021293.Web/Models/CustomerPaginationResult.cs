using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang cho khách hàng
    /// </summary>
    public class CustomerPaginationResult : BasePaginationResult
    {
        /// <summary>
        /// Danh sách khách hàng
        /// </summary>
        public List<Customer> Data { get; set; }
    }
}
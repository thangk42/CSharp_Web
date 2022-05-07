using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV18T1021293.Web.Models
{
    /// <summary>
    /// Lưu trữ thông tin đầu vào để tìm kiếm phân trang đơn giản
    /// </summary>
    public class PaginationSearchInput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SearchValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }
    }
}
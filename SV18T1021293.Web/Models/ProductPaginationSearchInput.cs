using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV18T1021293.Web.Models
{
    /// <summary>
    /// Lưu trữ thông tin đầu vào cho tìm kiếm có bộ lọc
    /// </summary>
    public class ProductPaginationSearchInput : PaginationSearchInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string categoryID;
        /// <summary>
        /// 
        /// </summary>
        public string supplierID;
    }
}
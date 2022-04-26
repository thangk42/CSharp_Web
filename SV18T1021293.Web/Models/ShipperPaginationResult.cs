using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Models
{
    /// <summary>
    /// Kết quả tìm kiếm, phân trang cho người giao hàng
    /// </summary>
    public class ShipperPaginationResult : BasePaginationResult
    {
        /// <summary>
        /// Danh sách ngời giao hàng
        /// </summary>
        public List<Shipper> Data { get; set; }
    }
}
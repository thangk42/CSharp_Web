using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductPaginationResult : BasePaginationResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Product> Data { get; set; }
    }
}
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
    public class EmployeePaginationResult : BasePaginationResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Employee> Data { get; set; }
    }
}
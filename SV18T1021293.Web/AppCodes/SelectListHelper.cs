using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SV18T1021293.BusinessLayer;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web
{
    /// <summary>
    /// Cung cấp các hàm tiện ích liên quan đến danh sách chọn trong thẻ Select
    /// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Danh sách quốc gia
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Countries()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "--Chọn quốc gia--"
            });
            foreach(var c in CommonDataService.ListOfCountries())
            {
                list.Add(new SelectListItem()
                {
                    Value = c.ContryName,
                    Text = c.ContryName,
                });
            }

            return list;
        }
        /// <summary>
        /// Danh sách nhà cung cấp
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Suppliers()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "0",
                Text = "--Chọn nhà cung cấp--"
            });
            foreach (var c in CommonDataService.ListOfSuppliers())
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(c.SupplierID),
                    Text = c.SupplierName,
                });
            }

            return list;
        }
        /// <summary>
        /// Danh sách loại hàng
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> Categories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "0",
                Text = "--Loại hàng--"
            });
            foreach (var c in CommonDataService.ListOfCategories())
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(c.CategoryID),
                    Text = c.CategoryName,
                });
            }

            return list;
        }
        public static List<SelectListItem> Customers()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Value = "",
                Text = "--Khách hàng--"
            });
            foreach (var c in CommonDataService.ListOfCustomers())
            {
                list.Add(new SelectListItem()
                {
                    Value = Convert.ToString(c.CustomerID),
                    Text = c.CustomerName,
                });
            }

            return list;
        }

    }
}
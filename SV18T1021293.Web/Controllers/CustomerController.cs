using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SV18T1021293.BusinessLayer;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        // GET: Customer
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Models.PaginationSearchInput model = Session["CUSTOMER_SEARCH"] as Models.PaginationSearchInput;
            if(model == null)
            {
                model = new Models.PaginationSearchInput()
                {
                    Page = 1,
                    PageSize = 10,
                    SearchValue = ""
                };
            }
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ActionResult Search(Models.PaginationSearchInput input)
        {
            int rowCount = 0;
            var data = CommonDataService.ListOfCustomers(input.Page, input.PageSize, input.SearchValue, out rowCount);

            Models.BasePaginationResult model = new Models.CustomerPaginationResult
            {
                Page = input.Page,
                PageSize = input.PageSize,
                RowCount = rowCount,
                SearchValue = input.SearchValue,    
                Data = data
            };

            Session["CUSTOMER_SEARCH"] = input;
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  ActionResult Create()
        {

            Customer model = new Customer()
            {
                CustomerID = 0
            };
            ViewBag.Title = "Bổ sung khách hàng";
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [Route("edit/{customerID}")]
        public ActionResult Edit(string customerID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(customerID);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            Customer model = CommonDataService.GetCustomer(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Cập nhật thông tin khách hàng";
            return View("Create",model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Customer model)
        {
            if (string.IsNullOrWhiteSpace(model.CustomerName))
                ModelState.AddModelError("CustomerName", "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(model.ContactName))
                ModelState.AddModelError("ContactName","Tên giao dịch không được để trống");
            if (string.IsNullOrWhiteSpace(model.Address))
                ModelState.AddModelError("Address", "Địa chỉ không được để trống");
            if (string.IsNullOrWhiteSpace(model.Country))
                ModelState.AddModelError("Country", "Quốc gia  không được để trống");
            if (string.IsNullOrWhiteSpace(model.City))
                ModelState.AddModelError("City", "Thành phố không được để trống");
            if (string.IsNullOrWhiteSpace(model.PostalCode))
                ModelState.AddModelError("PostalCode", "Mã bưu chính không được để trống");
            if (!ModelState.IsValid)
            {
               
                return View("Create", model);
            }
            if(model.CustomerID == 0)
            {
                CommonDataService.AddCustomer(model);
                return RedirectToAction("Index");
            }
            else
            {
                CommonDataService.UpdateCustomer(model);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        [Route("delete/{customerID}")]
        public ActionResult Delete(string customerID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(customerID);
            }
            catch
            {
                return RedirectToAction("Index");
            }
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            var model = CommonDataService.GetCustomer(id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
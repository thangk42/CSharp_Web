using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV18T1021293.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [RoutePrefix("supplier")]
    public class SupplierController : Controller
    {
        // GET: Supplier
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Bổ sung nhà cung cấp";
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("edit/{supplierID}")]
        public ActionResult Edit(int supplierID)
        {
            ViewBag.Title = "Cập nhật thông tin nhà cung cấp";
            return View("Create");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("delete/{supplierID}")]
        public ActionResult Delete(int supplierID)
        {
            return View();
        }
    }
}
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
    [RoutePrefix("shipper")]
    public class ShipperController : Controller
    {
        // GET: Shipper
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
            ViewBag.Title = "Bổ sung người giao hàng";
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        [Route("edit/{shipperID}")]
        public ActionResult Edit(int shipperID)
        {
            ViewBag.Tilte = "Cập nhật thông tin người giao hàng";
            return View("Create");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        [Route("delete/{shipperID}")]
        public ActionResult Delete(int shipperID)
        {
            return View();
        }
    }
}
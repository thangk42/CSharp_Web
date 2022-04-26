using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SV18T1021293.BusinessLayer;
using SV18T1021293.DomainModel;

namespace SV18T1021293.Web.Controllers
{/// <summary>
/// 
/// </summary>
    [Authorize]
    [RoutePrefix("employee")]
    public class EmployeeController : Controller
    {
        // GET: Employee
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int pageSize = 10;
            int rowCount = 0;
            var data = CommonDataService.ListOfEmployees(page, pageSize, searchValue, out rowCount);

            Models.BasePaginationResult model = new Models.EmployeePaginationResult
            {
                Page = page,
                PageSize = pageSize,
                RowCount = rowCount,
                SearchValue = searchValue,
                Data = data
            };
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            Employee model = new Employee()
            {
                EmployeeID = 0
            };
            ViewBag.Title = "Bổ sung nhân viên ";
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("edit/{employeeID}")]
        public ActionResult Edit(int employeeID)
        {

            Employee model = CommonDataService.GetEmployee(employeeID);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Title = "Cập nhật thông tin nhân viên";
            return View("Create", model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Employee model, HttpPostedFileWrapper photo)
        {
            if (photo != null && photo.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Avatars"),
                                            Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);
                    model.Photo = "/Avatars/" + photo.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.MessageFile = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                Employee employeeTemp = CommonDataService.GetEmployee(model.EmployeeID);
                if (employeeTemp != null)
                {
                    model.Photo = employeeTemp.Photo;
                }
                else
                {
                    model.Photo = "https://randomuser.me/api/portraits/men/3.jpg";
                }
            }
            if (string.IsNullOrWhiteSpace(model.FirstName))
                ModelState.AddModelError("FirstName", "Họ không được để trống");
            if (string.IsNullOrWhiteSpace(model.LastName))
                ModelState.AddModelError("LastName", "Tên không được để trống");
            if (model.BirthDate == null)
                ModelState.AddModelError("BirthDate", "Ngày sinh không được để trống");
            if (string.IsNullOrWhiteSpace(model.Email))
                ModelState.AddModelError("Email", "Email không được để trống");
            if (string.IsNullOrWhiteSpace(model.Note))
                ModelState.AddModelError("Note", "Ghi chú không được để trống");
            if (!ModelState.IsValid)
            {

                return View("Create", model);
            }
            if (model.EmployeeID == 0)
            {
                CommonDataService.AddEmployee(model);
                return RedirectToAction("Index");
            }
            else
            {
                CommonDataService.UpdateEmployee(model);
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("delete/{employeeID}")]
        public ActionResult Delete(int employeeID)
        {
            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteEmployee(employeeID);
                return RedirectToAction("Index");
            }
            var model = CommonDataService.GetEmployee(employeeID);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
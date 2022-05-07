using System;
using System.Collections.Generic;
using System.Globalization;
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
            Models.PaginationSearchInput model = Session["EMPLOYEE_SEARCH"] as Models.PaginationSearchInput;
            if (model == null)
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
            var data = CommonDataService.ListOfEmployees(input.Page, input.PageSize, input.SearchValue, out rowCount);

            Models.BasePaginationResult model = new Models.EmployeePaginationResult
            {
                Page = input.Page,
                PageSize = input.PageSize,
                RowCount = rowCount,
                SearchValue = input.SearchValue,
                Data = data
            };

            Session["EMPLOYEE_SEARCH"] = input;
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
                EmployeeID = 0,
                BirthDate = DateTime.Today
            };
            ViewBag.Title = "Bổ sung nhân viên ";

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("edit/{employeeID?}")]
        public ActionResult Edit(string employeeID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(employeeID);
            }
            catch
            {
                return RedirectToAction("Index");
            }

            Employee model = CommonDataService.GetEmployee(id);
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
        public ActionResult Save(Employee model, HttpPostedFileWrapper uploadPhoto, string dateOfBirth)
        {
            //Tự làm
            /*if (photo != null && photo.ContentLength > 0)
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
            if (string.IsNullOrWhiteSpace(model.BirthDate.ToString()))
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
            }*/

            //TODO: Kiểm tra FirstName, LastName, Email, Note,...

            if (string.IsNullOrWhiteSpace(model.FirstName))
                ModelState.AddModelError("FirstName", "Họ không được để trống");
            if (string.IsNullOrWhiteSpace(model.LastName))
                ModelState.AddModelError("LastName", "Tên không được để trống");
            if (string.IsNullOrWhiteSpace(model.Email))
                ModelState.AddModelError("Email", "Email không được để trống");
            if (string.IsNullOrWhiteSpace(model.Note))
                ModelState.AddModelError("Note", "Ghi chú không được để trống");

            //Chuyển cái dateOfBirth(dd/MM/yyyy) sang kiểu datetime
            try
            {
                model.BirthDate = DateTime.ParseExact(dateOfBirth, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                ModelState.AddModelError("BirthDate", $"Ngày sinh {dateOfBirth} phải nhập theo đúng định dạng");

            }

            //Upload ảnh
            if (uploadPhoto != null)
            {
                string physicalPath = Server.MapPath("~/Images/Employees");
                string filename = $"{DateTime.Now.Ticks}_{uploadPhoto.FileName}";
                string filePath = System.IO.Path.Combine(physicalPath, filename);
                uploadPhoto.SaveAs(filePath);
                model.Photo = $"Images/Employees/{filename}";
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Title = model.EmployeeID == 0 ? "Bổ sung nhân viên" : "Cập nhật nhân viên";
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
        [Route("delete/{employeeID?}")]
        public ActionResult Delete(string employeeID)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(employeeID);
            }
            catch
            {
                return RedirectToAction("Index");
            }

            if (Request.HttpMethod == "POST")
            {
                CommonDataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            var model = CommonDataService.GetEmployee(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
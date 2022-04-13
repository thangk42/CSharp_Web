using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV18T1021293.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        /// <summary>
        /// Tạo giao diện đăng nhập
        /// </summary>
        /// <returns></returns>
      [AllowAnonymous]
      [HttpGet]
      public ActionResult Login()
        {

            return View();
        }
        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //TODO: Code lại để kiểm tra tài khoản trong cơ sơ dữ liệu
            if(username == "admin@abc.com" && password == "1")
            {
                //Ghi lại cookie phiên đăng nhập
                System.Web.Security.FormsAuthentication.SetAuthCookie(username,false);
                return RedirectToAction("Index","Home");
            }
            ViewBag.UserName = username;
            ViewBag.Message = "Đăng nhập thất bại";
            return View();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
      public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
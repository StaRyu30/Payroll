using Payroll.DataModel;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Payroll.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //post register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserViewModel user)
        {
            bool status = false;
            string message = "";

            //model validation
            if (ModelState.IsValid)
            {
                //check user exist
                var isExist = IsUserExist(user.Username);
                if (isExist)
                {
                    ModelState.AddModelError("UserExist", "user already exist");
                    return View(user);
                }

                //password hashing
                user.Password = Crypto.Hash(user.Password);

                Responses responses = UserRepo.Update(user);
                if (responses.Success)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                message = "Invalid Request";
            }
            return View(user);
        }

        //login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //post login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl = "")
        {
            string message = "";
            using (var db = new PayrollContext())
            {
                var v = db.Users.Where(o => o.Username == login.Username).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //in mins
                        var ticket = new FormsAuthenticationTicket(login.Username, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }


        [NonAction]
        public bool IsUserExist(string user)
        {
            return UserRepo.UserExist(user);
        }
    }
}
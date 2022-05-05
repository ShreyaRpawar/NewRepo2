using Employee_Onboarding.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;
using Microsoft.AspNetCore.Http;


namespace Employee_Onboarding.Controllers
{
    public class userController : Controller
    {
       private OnboardingContext context = new OnboardingContext();

        public IActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = context.Users.FirstOrDefault(s => s.EmailId == s.EmailId);
                if (check == null)
                {
                    user.UserPassword = GetMD5(user.UserPassword);
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Userlogin userlogin)
        {
            if (ModelState.IsValid)
            {
                var fpassword = GetMD5(userlogin.UserPassword);
                var data = context.Users.Where(s => s.EmailId.Equals(userlogin.EmailId) && s.UserPassword.Equals(fpassword)).ToList();
                if (data.Count() > 0)
                {
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().EmailId;
                    Session["UserId"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}

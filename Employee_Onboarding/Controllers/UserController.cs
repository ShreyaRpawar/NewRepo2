using Employee_Onboarding.Models;
using Employee_Onboarding.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class UserController : Controller
    {
        private readonly ILRService<User, int> userserv;
        private readonly ILRService<Register, int> regserv;

        public UserController(ILRService<User, int> userserv, ILRService<Register, int> regserv)
        {
            this.userserv = userserv;
            this.regserv = regserv;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var res = new User();
            return View(res);
        }

       // [HttpPost]
        // public async Task<IActionResult> Index(User user)
        //{
        //    var res = userserv.GetAsync().Result.Where(x => x.EmailId == user.EmailId).FirstOrDefault();
        //    if (res == null)
        //    {
        //        ViewBag.Message = "Wrong Credential";
        //        return View(user);
        //    }
        //    if (user.Email == res.Email)
        //    {
        //        var decryptedPassword = await DecryptAsync(res.UserPassword);
        //        if (user.UserPassword == decryptedPassword)
        //        {
        //            if (res.RoleId == 1)
        //            {
        //                return RedirectToAction("Index", "Student");
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Admin");
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Wrong Password";
        //            return View(user);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Wrong EmailID";
        //        return View(user);
        //    }
        //}

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //public IActionResult Create(User user)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        user.SignIn = DateTime.Now;
        //        var password = EncryptAsync(user.UserPassword).Result;
        //        string str = user.Email.Substring(0, 4);

        //        string strnew = str;
        //        user.Email = strnew;
        //        user.UserPassword = password;
        //        var res = regserv.CreateAsync(user).Result;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Wrong EmailID";
        //        return View(user);
        //    }
        //}
    }
}


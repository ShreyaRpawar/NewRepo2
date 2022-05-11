using Employee_Onboarding.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;

namespace Employee_Onboarding.Controllers
{
    public class userController : Controller
    {
        public object FormsAuthentication { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveRegisterDetails(User user)
        {
            if (ModelState.IsValid)
            {
                using (var OnboardingContext = new OnboardingContext())
                {
                    User user1 = new User();
                    user1.FirstName = user.FirstName;
                    user1.LastName = user.LastName;
                    user1.EmailId = user.EmailId;
                    user1.UserPassword = user.UserPassword;

                    OnboardingContext.Add(user1);
                    OnboardingContext.SaveChanges();

                }

                ViewBag.Message = "User details wrong";
                return View("User");
            }
            else
            {
                return View("User", user);
            }
        }
        [HttpPost]
        public ActionResult Login(Userlogin login)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = IsValidUser(login);
                if (isValidUser != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }

            }
            else
            {
                return View(login);
            }

        }

        public User IsValidUser(Userlogin login)
        {
            using (var OnboardingContext = new OnboardingContext())
            {
                User user = OnboardingContext.Users.Where(query => query.EmailId.Equals(login.EmailId) && query.UserPassword.Equals(login.UserPassword)).SingleOrDefault();
                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
        }
    }

}
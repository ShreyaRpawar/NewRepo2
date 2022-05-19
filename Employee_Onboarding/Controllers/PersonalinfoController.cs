using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class PersonalinfoController : Controller
    {
        private readonly IService<Personalinfo, int> personalservice;

        public PersonalinfoController(IService<Personalinfo, int> service)
        {
            personalservice = service;
        }

        public IActionResult Index()
        {
            var res = personalservice.GetAsync().Result;
            return View();
        }

        public IActionResult Create()
        {
            var res = new Personalinfo();
            return View(res);
        }

        [HttpPost]
        public IActionResult Create(Personalinfo info)
        {
                var personal = info;
                HttpContext.Session.SetObject<Personalinfo>("Personalinfo", personal);
                return RedirectToAction("Create", "Educationalinfo");
        }

        public IActionResult ValidateName(string FullName)
        {

            Regex reg = new Regex("^([a-zA-Z]+( [a-zA-Z]+)+)$");
            if (reg.IsMatch(Convert.ToString(FullName)))
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: false);
            }
        }

       
    }
}

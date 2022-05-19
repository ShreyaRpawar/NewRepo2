using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Employee_Onboarding.SessionExtension;
using System;

namespace Employee_Onboarding.Controllers
{
    public class EducationalinfoController : Controller
    {
        private readonly IService<Educationinfo, int> educationanservice;
        private readonly IService<Personalinfo, int> personalservice;


        public EducationalinfoController(IService<Educationinfo, int> service, IService<Personalinfo, int> perservice)
        {
            educationanservice = service;
            personalservice = perservice;
        }
        public IActionResult Index()
        {
            var res = educationanservice.GetAsync().Result;
            return View();
        }

        public IActionResult Create()
        {
            var res = new Educationinfo();
            return View(res);

        }

        [HttpPost]
        public async Task< IActionResult> Create(Educationinfo info)
        {
                var education = info;
                HttpContext.Session.SetObject<Educationinfo>("Educationinfo", education);
                return RedirectToAction("Create", "Professionalinfo");


        }

    }
}


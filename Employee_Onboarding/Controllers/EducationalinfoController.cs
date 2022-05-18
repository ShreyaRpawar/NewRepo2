using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Employee_Onboarding.SessionExtension;


namespace Employee_Onboarding.Controllers
{
    public class EducationalinfoController : Controller
    {
        private readonly IService<Educationinfo, int> eduserv;
        private readonly IService<Personalinfo, int> perservice;


        public EducationalinfoController(IService<Educationinfo, int> service, IService<Personalinfo, int> perservice)
        {
            eduserv = service;
            this.perservice = perservice;
        }
        public IActionResult Index()
        {
            var res = eduserv.GetAsync().Result;
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
            HttpContext.Session.SetObject<Educationinfo>("Educationinfo",education);

            var personalInfo =HttpContext.Session.GetObject<Personalinfo>("Personalinfo");
            var res = perservice.CreateAsync(personalInfo).Result;
            info.EmployeeId = res.EmployeeId;
            var edu =await eduserv.CreateAsync(info);
            return RedirectToAction("Create", "Professionalinfo");
        }

    }
}

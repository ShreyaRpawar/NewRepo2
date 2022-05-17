using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class ProfessionalinfoController : Controller
    {
        private readonly IService<Professionalinfo , int >proserv;

        public ProfessionalinfoController(IService<Professionalinfo, int> service)
        {
            proserv = service;
        }

        public IActionResult Index()
        {
            var res = proserv.GetAsync().Result;
            return View();
        }

        public IActionResult Create()
        {
            var res = new Professionalinfo();
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professionalinfo info)
        {
            var professional = info;
            HttpContext.Session.SetObject<Professionalinfo>("Professionalinfo", professional);
            var res = await proserv.CreateAsync(info);
            return RedirectToAction("FileUpload", "FileUpload");
        }
    }
}

using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class ProfessionalinfoController : Controller
    {
        private readonly IService<Professionalinfo, int> proserv;
        private readonly IService<Personalinfo, int> perservice;
        private readonly IService<Educationinfo, int> eduserv;



        public ProfessionalinfoController(IService<Professionalinfo, int> service, IService<Personalinfo, int> perservice, IService<Educationinfo, int> eduserv)
        {
            proserv = service;
            this.perservice = perservice;
            this.eduserv = eduserv;
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

            var educationInfo = HttpContext.Session.GetObject<Educationinfo>("Educationinfo");
            var personalInfo = HttpContext.Session.GetObject<Personalinfo>("Personalinfo");

            HttpContext.Session.SetObject<Professionalinfo>("Professionalinfo", professional);

            var res = await proserv.CreateAsync(info);
            return RedirectToAction("FileUpload", "FileUpload");
        }
    }
}

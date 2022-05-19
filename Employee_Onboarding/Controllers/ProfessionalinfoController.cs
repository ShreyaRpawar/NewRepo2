using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class ProfessionalinfoController : Controller
    {
        private readonly IService<Professionalinfo, int> professionalservice;
        private readonly IService<Personalinfo, int> personalservice;
        private readonly IService<Educationinfo, int> educationservice;
       


        public ProfessionalinfoController(IService<Professionalinfo, int> professionalservice, IService<Personalinfo, int> personalservice, IService<Educationinfo, int> educationservice)
        {
            this.professionalservice = professionalservice;
            this.personalservice = personalservice;
            this.educationservice = educationservice;
        }

        public IActionResult Index()
        {
            var res = professionalservice.GetAsync().Result;
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
          
                HttpContext.Session.SetObject<Professionalinfo>("Professionalinfo", info);
                return RedirectToAction("FileUpload", "FileUpload");
          
        }
    }
}

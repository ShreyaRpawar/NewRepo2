using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class PersonalinfoController : Controller
    {
        private readonly IService<Personalinfo, int> perservice;

        public PersonalinfoController(IService<Personalinfo, int> serv)
        {
            perservice = serv;
        }

        public IActionResult Index()
        {
            var res = perservice.GetAsync().Result;
            return View();
        }

        public IActionResult Create()
        {
            var res = new Personalinfo();
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personalinfo info)
        {
            var personal = info;
            HttpContext.Session.SetObject<Personalinfo>("Personalinfo", personal);
            var res = await perservice.CreateAsync(info);
            return RedirectToAction("Create", "Educationalinfo");
        }
    }
}

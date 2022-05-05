using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
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
            var res = await perservice.CreateAsync(info);

            return RedirectToAction("Create", "Educationalinfo");
        }
    }
}

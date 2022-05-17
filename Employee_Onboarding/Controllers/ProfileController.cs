using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Onboarding.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IService<Personalinfo, int> perserv;
        private readonly IService<Educationinfo, int> eduserv;
        private readonly IService<Professionalinfo, int> proserv;

        public ProfileController(IService<Personalinfo, int> perserv, IService<Educationinfo, int> eduserv, IService<Professionalinfo, int> proserv)
        {
            this.perserv= perserv;
            this.eduserv= eduserv;
            this.proserv= proserv;
        }
        public IActionResult Index()
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
            //null checks
            var res1 = perserv.GetAsync().Result;
            var res2 = proserv.GetAsync().Result;

            var res3 = from p in res1
                       join r in res2 on
                       p.EmployeeId equals r.EmployeeId
                       select new
                       {
                           EmployeeId = p.EmployeeId,
                           FullName = p.Fullname,
                           FieldOfExperience = r.FieldOfExperience,
                           Passportfilepath = p.Passportfilepath
                       };

            List<profile> profile = new List<profile>();
            foreach (var p in res3)
            {
                profile profile1 = new profile();
                //profile1.EmployeeId =
                profile.Add(new profile()
                {
                    EmployeeId = p.EmployeeId,
                    Fullname = p.FullName,
                    FieldOfExperience = p.FieldOfExperience,
                    Passportfilepath = p.Passportfilepath

                });
            }
            return View(profile);
        }

        public IActionResult Details(int id)
        {
            empData empdata = new empData();
            var res = perserv.GetAsync(id).Result;
            empdata.EmployeeId = res.EmployeeId;
            empdata.Fullname = res.Fullname;
            empdata.Gender = res.Gender;
            empdata.LocalityAddress = res.LocalityAddress;
            empdata.StateN = empdata.StateN;
            empdata.City = res.City;
            empdata.Contactno = res.Contactno;
            empdata.Emailid = res.Emailid;
            empdata.Passportfilepath = res.Passportfilepath;
            var res1 = eduserv.GetAsync().Result.Where(i => i.EmployeeId == id).FirstOrDefault();
            empdata.Educationid = res1.Educationid;
            empdata.SscSchoolName = res1.SscSchoolName;
            empdata.SscPercentage= res1.SscPercentage;
            empdata.SscPassingYear = res1.SscPassingYear;
            empdata.HscCollegeName = res1.HscCollegeName;
            empdata.HscPercentage = res1.HscPercentage;
            empdata.HscPassingYear = res1.HscPercentage;
            empdata.DegreeCollegeName = res1.DegreeCollegeName;
            empdata.DegreePercentage = res1.DegreePercentage;
            empdata.DegreePassingYear = res1.DegreePassingYear;
            empdata.University = res1.University;
            empdata.HighestQualificaion = res1.HighestQualificaion;
            var res2 = proserv.GetAsync().Result.Where(i => i.EmployeeId == id).FirstOrDefault();
            empdata.Professionalid = res2.Professionalid;
            empdata.WorkExperience = res2.WorkExperience;
            empdata.Company = res2.Company;
            empdata.FieldOfExperience = res2.FieldOfExperience;
            empdata.Experties = res2.Experties;

            return View(empdata);
        }



    }
}

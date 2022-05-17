using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using Employee_Onboarding.SessionExtension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class FileUploadController : Controller
    {
        IWebHostEnvironment hostEnvironment;
        private readonly IService<Personalinfo, int> perserv;
        private readonly IService<Educationinfo, int> eduserv;
        private readonly IService<Professionalinfo, int> proserv;

        public FileUploadController(IWebHostEnvironment hostEnvironment, IService<Personalinfo, int> perserv, IService<Educationinfo, int> eduserv, IService<Professionalinfo, int> proserv)
        {
            this.perserv = perserv;
            this.eduserv = eduserv;
            this.proserv = proserv;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FileUpload()
        {
            documentsUpload upload = new documentsUpload();
            return View(upload);
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(documentsUpload data)
        {
            IFormFile file = data.ProfilePicture;
            IFormFile Resume = data.Resume;
            IFormFile Sign = data.Sign;
            IFormFile AdharCard = data.AdharCard;
            IFormFile Sscfile = data.SscReport;
            IFormFile Hscfile = data.HscReport;
            IFormFile Degree = data.DegreeReport;


            var ProfileFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var ResumeFileName = ContentDispositionHeaderValue.Parse(Resume.ContentDisposition).FileName.Trim('"');
            var signfilename = ContentDispositionHeaderValue.Parse(Sign.ContentDisposition).FileName.Trim('"');
            var adharfilename = ContentDispositionHeaderValue.Parse(AdharCard.ContentDisposition).FileName.Trim('"');
            var Sscfilename = ContentDispositionHeaderValue.Parse(Sscfile.ContentDisposition).FileName.Trim('"');
            var Hscfilename = ContentDispositionHeaderValue.Parse(Hscfile.ContentDisposition).FileName.Trim('"');
            var Degreefilename = ContentDispositionHeaderValue.Parse(Degree.ContentDisposition).FileName.Trim('"');


            FileInfo fileInfo = new FileInfo(ProfileFileName);
            FileInfo fileInfo1 = new FileInfo(ResumeFileName);
            FileInfo fileInfo2 = new FileInfo(signfilename);
            FileInfo fileInfo3 = new FileInfo(adharfilename);
            FileInfo fileInfo4 = new FileInfo(Sscfilename);
            FileInfo fileInfo5 = new FileInfo(Hscfilename);
            FileInfo fileInfo6 = new FileInfo(Degreefilename);


            if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
            {
                var finalPathImage = Path.Combine(hostEnvironment.WebRootPath, "images", ProfileFileName);
                using (var fs = new FileStream(finalPathImage, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                data.ProfileFileName = @$"~/images/{file.FileName}";
                HttpContext.Session.SetString("imgPath", data.ProfileFileName);
                data.ProfileUploadStatus = "File is Uploaded Successfully";
            }
            else
            {
                data.ProfileUploadStatus = "Failed to Upload Profile Picture......";
                return View(data);
            }
            if (fileInfo1.Extension == ".pdf" )
            {
                var finalPathResume = Path.Combine(hostEnvironment.WebRootPath, "PDF", ResumeFileName);
                var temp = HttpContext.Session.GetString("imgPath").ToString();
                using (var fs = new FileStream(finalPathResume, FileMode.OpenOrCreate))
                {
                    await Resume.CopyToAsync(fs);
                }
                data.ResumeFileName = @$"~/PDF/{Resume.FileName}";
                HttpContext.Session.SetString("resumePath", data.ResumeFileName);
                data.ResumeUploadStatus = "Resume Uploded Successfully";
            }
            else
            {
                data.ResumeUploadStatus = "Failed to Upload Resume......";
                return View(data);
            }
            if (fileInfo2.Extension == ".pdf")
            {
                var finalPathSign = Path.Combine(hostEnvironment.WebRootPath, "PDF", signfilename);
                var temp = HttpContext.Session.GetString("signpath").ToString();
                using (var fs = new FileStream(finalPathSign, FileMode.OpenOrCreate))
                {
                    await Sign.CopyToAsync(fs);
                }
                data.signfilename = @$"~/PDF/{Sign.FileName}";
                HttpContext.Session.SetString("SignPath", data.signfilename);
                data.signUploadStatus = "Sign Uploaded successfully";
            }
            else
            {
                data.signUploadStatus = "File Upload failed";
                return View(data);
            }
            if (fileInfo3.Extension == ".pdf")
            {
                var finalPathAdhar = Path.Combine(hostEnvironment.WebRootPath, "PDF", adharfilename);
                var temp = HttpContext.Session.GetString("adharpath").ToString();
                using (var fs = new FileStream(finalPathAdhar, FileMode.OpenOrCreate))
                {
                    await AdharCard.CopyToAsync(fs);
                }
                data.adharfilename = @$"~/PDF/{AdharCard.FileName}";
                HttpContext.Session.SetString("Adharcard", data.adharfilename);
                data.adharUploadStatus = "Sign Uploaded successfully";
            }
            else
            {
                data.adharUploadStatus = "File Upload failed";
                return View(data);
            }

            if (fileInfo4.Extension == ".pdf")
            {
                var finalPathSsc = Path.Combine(hostEnvironment.WebRootPath, "PDF", Sscfilename);
                var temp = HttpContext.Session.GetString("Sscpath").ToString();
                using (var fs = new FileStream(finalPathSsc, FileMode.OpenOrCreate))
                {
                    await Sscfile.CopyToAsync(fs);
                }
                data.Sscfilename = @$"~/PDF/{Sscfile.FileName}";
                HttpContext.Session.SetString("Sscfile", data.Sscfilename);
                data.SscReportUploadStatus = "Ssc report Uploaded successfully";
            }
            else
            {
                data.SscReportUploadStatus = "Ssc Report Upload failed";
                return View(data);
            }
            if (fileInfo5.Extension == ".pdf")
            {
                var finalPathHsc = Path.Combine(hostEnvironment.WebRootPath, "PDF", Hscfilename);
                var temp = HttpContext.Session.GetString("Hscpath").ToString();
                using (var fs = new FileStream(finalPathHsc, FileMode.OpenOrCreate))
                {
                    await Hscfile.CopyToAsync(fs);
                }
                data.Hscfilename = @$"~/PDF/{Hscfile.FileName}";
                HttpContext.Session.SetString("Hscfile", data.Hscfilename);
                data.HscUploadStatus = "Hsc report Uploaded successfully";
            }
            else
            {
                data.HscUploadStatus = "Hsc Report Upload failed";
                return View(data);
            }
            if (fileInfo6.Extension == ".pdf")
            {
                var finalPathDegree = Path.Combine(hostEnvironment.WebRootPath, "PDF", Degreefilename);
                var temp = HttpContext.Session.GetString("Degreepath").ToString();
                using (var fs = new FileStream(finalPathDegree, FileMode.OpenOrCreate))
                {
                    await Degree.CopyToAsync(fs);
                }
                data.Degreefilename = @$"~/PDF/{Degree.FileName}";
                HttpContext.Session.SetString("Degee", data.Degreefilename);
                data.DegreeReportUploadStatus = "Degree report Uploaded successfully";
            }
            else
            {
                data.DegreeReportUploadStatus = "Degree Report Upload failed";
                return View(data);
            }


            return RedirectToAction("UploadData");

        }
        public IActionResult UploadData()
        {
            var Personalinfo = HttpContext.Session.GetObject<Personalinfo>("Personalinfo");
            Personalinfo.Passportfilepath = Convert.ToString(HttpContext.Session.GetString("imgPath"));
            Personalinfo.Resumefilepath = Convert.ToString(HttpContext.Session.GetString("resumePath"));
            Personalinfo.Signaturefilepath = Convert.ToString(HttpContext.Session.GetString("SignPath"));
            Personalinfo.Sscfilepath = Convert.ToString(HttpContext.Session.GetString("SscPath"));
            Personalinfo.Hscfilepath = Convert.ToString(HttpContext.Session.GetString("HscPath"));
            Personalinfo.Degreefilepath = Convert.ToString(HttpContext.Session.GetString("DegreePath"));

            var r = Personalinfo;
            var result = perserv.CreateAsync(Personalinfo).Result;
            var education = HttpContext.Session.GetObject<Educationinfo>("Educationinfo");
            education.EmployeeId = result.EmployeeId;
            var result1 = eduserv.CreateAsync(education).Result;
            var professional = HttpContext.Session.GetObject<Professionalinfo>("Professionalinfo");

            professional.EmployeeId = result.EmployeeId;
            var temp = proserv.CreateAsync(professional).Result;
          
            return RedirectToAction("Index", "Home");
        }
    }
}


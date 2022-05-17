using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Employee_Onboarding.Models
{
    public class documentsUpload
    {
        [Display(Name = "Image")]
        public IFormFile ProfilePicture { get; set; }
        public string ProfileUploadStatus { get; set; }
        public string ProfileFileName { get; set; }


        [Display(Name = "Resume")]
        public IFormFile Resume { get; set; }
        public string ResumeUploadStatus { get; set; }
        public string ResumeFileName { get; set; }


        [Display(Name = "Signature")]
        public IFormFile Sign { get; set; }
        public string signUploadStatus { get; set; }
        public string signfilename { get; set; }


        [Display(Name = "AdharCard")]
        public IFormFile AdharCard { get; set; }
        public string adharUploadStatus { get; set; }
        public string adharfilename { get; set; }


        [Display(Name = "SSC Result")]
        public IFormFile SscReport { get; set; }
        public string SscReportUploadStatus { get; set; }
        public string Sscfilename { get; set; }


        [Display(Name = "HSC Result")]
        public IFormFile HscReport { get; set; }
        public string HscUploadStatus { get; set; }
        public string Hscfilename { get; set; }


        [Display(Name = "Degree Result")]
        public IFormFile DegreeReport { get; set; }
        public string DegreeReportUploadStatus { get; set; }    
        public string Degreefilename { get; set; }
        
    }
}

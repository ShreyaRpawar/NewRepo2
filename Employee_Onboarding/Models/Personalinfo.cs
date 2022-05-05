using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class Personalinfo
    {
        public Personalinfo()
        {
            Educationinfos = new HashSet<Educationinfo>();
            Professionalinfos = new HashSet<Professionalinfo>();
        }

        public int EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string LocalityAddress { get; set; }
        public string StateN { get; set; }
        public string City { get; set; }
        public int Contactno { get; set; }
        public string Emailid { get; set; }
        public string Passportfilepath { get; set; }
        public string Signaturefilepath { get; set; }
        public string Adharcardfilepath { get; set; }
        public string Sscfilepath { get; set; }
        public string Hscfilepath { get; set; }
        public string Degreefilepath { get; set; }
        public string Resumefilepath { get; set; }

        public virtual ICollection<Educationinfo> Educationinfos { get; set; }
        public virtual ICollection<Professionalinfo> Professionalinfos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class Professionalinfo
    {
        public int Professionalid { get; set; }
        public int EmployeeId { get; set; }
        public string WorkExperience { get; set; }
        public string Company { get; set; }
        public string FieldOfExperience { get; set; }
        public string Experties { get; set; }

        public virtual Personalinfo Employee { get; set; }
    }
}
